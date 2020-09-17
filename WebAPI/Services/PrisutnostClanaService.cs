using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;

namespace WebAPI.Services
{
    public class PrisutnostClanaService : BaseCRUDService<Model.PrisutnostClana, PrisutnostClanaSearchRequest, PrisutnostClanaInsertRequest, object, Database.PrisutnostClana>
    {
        public PrisutnostClanaService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        
        public override List<Model.PrisutnostClana> Get([FromQuery] PrisutnostClanaSearchRequest search)
        {
            List<Model.PrisutnostClana> result = new List<Model.PrisutnostClana>();
            if (search.Do == null && search.Od == null)
            {
                var query = _context.Set<PrisutnostClana>().AsQueryable();
                if (search.BrojKartice != null)
                {
                    query = query.Where(x => x.Korisnik.BrojKartice == search.BrojKartice);
                }
                result = query.Where(x => x.VrijemeOdlaska == null).Select(x => new Model.PrisutnostClana
                {
                    Id = x.Id,
                    VrijemeOdlaska = x.VrijemeOdlaska,
                    Datum = x.Datum,
                    Ime = x.Korisnik.Ime,
                    KorisnikId = x.KorisnikId,
                    Prezime = x.Korisnik.Prezime,
                    VrijemeDolaska = x.VrijemeDolaska
                }).ToList();

                result.ForEach(x =>
                {
                    List<Database.Clanarina> clanarine = _context.Clanarina.Where(y => y.KorisnikId == x.KorisnikId).ToList();
                    clanarine.ForEach(c =>
                    {
                        if (c.DatumDodavanja < DateTime.Today && c.DatumIsteka > DateTime.Today)
                            x.Aktivan = true;
                    });
                });
            }
            else
            {
                var list = _context.PrisutnostClana.Where(x => x.Datum > search.Od && x.Datum < search.Do).ToList();
                result = _mapper.Map<List<Model.PrisutnostClana>>(search);
            }
            return result;
        }
    }
}
