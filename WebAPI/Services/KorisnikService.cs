using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Model;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Database;
using WebAPI.Mail;

namespace WebAPI.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly RS2Context _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public KorisnikService(RS2Context context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        public Model.Korisnik Authenticiraj(string username, string pass)
        {
            var user = _context.Korisnik.Where(x => x.Username == username).Include(x => x.KorisnikUloga).FirstOrDefault();

            if (user != null)
            {
                var newHash = GenerateHash(user.PasswordSalt, pass);

                if (newHash == user.PasswordHash)
                {
                    var model = _mapper.Map<Model.Korisnik>(user);
                    model.KorisniciUloge = new List<KorisniciUloge>();
                    foreach (var x in user.KorisnikUloga)
                    {
                        Database.Uloga uloga = _context.Uloga.Find(x.UlogaId);
                        Model.KorisniciUloge temp = new KorisniciUloge
                        {
                            DatumIzmjene = x.DatumIzmjene,
                            Uloga = new Uloge
                            {
                                UlogaId = uloga.Id,
                                Naziv = uloga.Naziv,
                                Opis = uloga.Opis
                            },
                            KorisnikId = user.Id
                        };
                        model.KorisniciUloge.Add(temp);
                    }
                    return model;
                }
            }
            return null;




            //var user = _context.Korisnik.Where(x => x.Username == username).Include(x => x.KorisnikUloga).FirstOrDefault();

            //if (user != null)
            //{
            //    var newHash = GenerateHash(user.PasswordSalt, pass);

            //    if (newHash == user.PasswordHash)
            //    {
            //        var model = _mapper.Map<Model.Korisnik>(user);
            //        model.KorisniciUloge = new List<KorisniciUloge>();
            //        foreach (var x in user.KorisnikUloga)
            //        {
            //            Database.Uloga uloga = _context.Uloga.Find(x.UlogaId);
            //            Model.KorisniciUloge temp = new KorisniciUloge {
            //                DatumIzmjene = x.DatumIzmjene,
            //                Uloga = new Uloge
            //                {
            //                    UlogaId = uloga.Id,
            //                    Naziv = uloga.Naziv,
            //                    Opis = uloga.Opis
            //                },
            //                KorisnikId = user.Id
            //            };
            //            model.KorisniciUloge.Add(temp);
            //        }
            //        return model;
            //    }
            //}
            //return null;
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public List<Model.Korisnik> Get(KorisniciSearchRequest request)
        {
            var query = _context.Korisnik.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Ime) && !string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime) && x.Prezime.StartsWith(request.Prezime));
            }
            else if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }
            else if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));
            }
            else if (!string.IsNullOrWhiteSpace(request.Email))
            {
                query = query.Where(x => x.Email == request.Email);
            }
            else if (!string.IsNullOrWhiteSpace(request.BrojKartice))
            {
                query = query.Where(x => x.BrojKartice == request.BrojKartice);
            }
            else if (!string.IsNullOrWhiteSpace(request.Username))
            {
                query = query.Where(x => x.Username == request.Username);
            }
            

            var list = query.ToList();
            var tempList = new List<Database.Korisnik>();
            foreach (var x in list)
            {
                List<KorisnikUloga> uloge = _context.KorisnikUloga.Where(k => k.KorisnikId == x.Id && k.Uloga.Naziv == "Clan").ToList();
                if(uloge.Count > 0)
                {
                    tempList.Add(x);
                }
            }
            return _mapper.Map<List<Model.Korisnik>>(tempList);
        }

        public Model.Korisnik GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public string GenerateUsername(string ime, string prezime)
        {
            var username = ime.ToLower() + '.' + prezime.ToLower();
            int num = _context.Korisnik.Where(x => x.Username == username).Count();
            if (num == 0)
            {
                return username;
            }
            num++;
            username += num.ToString();
            return username;
        }

        public string RandomPass()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnik>(request);
            string _username;
            entity.Username = GenerateUsername(entity.Ime, entity.Prezime);
            string _password;
            if(request.Uloga == "Clan")
            {
                _password = RandomPass();
                _username = GenerateUsername(entity.Ime, entity.Prezime);
            }
            else
            {
                _password = request.Password;
                _username = request.Username;
            }
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, _password);
            entity.Username = _username;
            _context.Korisnik.Add(entity);
            _context.SaveChanges();
            var korisnikUloga = new KorisnikUloga
            {
                KorisnikId = entity.Id,
                UlogaId = _context.Uloga.Where(x => x.Naziv == request.Uloga).Select(x => x.Id).SingleOrDefault(),
                DatumIzmjene = DateTime.Today
            };
            if(request.Uloga == "Clan")
            {
                MailData mailData = new MailData
                {
                    SmtpServer = _config.GetValue<string>("MailData:SmtpServer"),
                    Port = _config.GetValue<int>("MailData:Port"),
                    Sender = _config.GetValue<string>("MailData:Sender"),
                    UserName = _config.GetValue<string>("MailData:UserName"),
                    Password = _config.GetValue<string>("MailData:Password")
                };
                string emailSubject = "Login podaci";
                string emailBody = "Username: " + entity.Username + "    Password:  " + _password;
                EmailMessage emailMessage = Email.CreateEmailMessage(mailData.Sender, entity.Email, emailSubject, emailBody);
                MimeMessage mimeMessage = Email.CreateMimeMessage(emailMessage);
                Email.Send(mimeMessage, mailData);
            }
            _context.KorisnikUloga.Add(korisnikUloga);
            _context.SaveChanges();
            return _mapper.Map<Model.Korisnik>(entity);
        }

        public Model.Korisnik Update(int id, KorisnikInsertRequest request)
        {

            var entity = _context.Set<Database.Korisnik>().Find(id);
            var clanSlika = entity.Slika;

            _mapper.Map(request, entity);
            if (entity.Slika.Length == 0)
            {
                entity.Slika = clanSlika;
            }

            _context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }

        public List<Model.Korisnik> Get()
        {
            throw new NotImplementedException();
        }

        public Model.Korisnik GetByBrojKartice(string brojKartice)
        {
            var korisnik = _context.Korisnik.Where(x => x.BrojKartice == brojKartice).SingleOrDefault();
            return _mapper.Map<Model.Korisnik>(korisnik);
        }
    }
}
