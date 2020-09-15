using AutoMapper;
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
            var query = _context.Set<PrisutnostClana>().AsQueryable();
            if (search.BrojKartice != null)
            {
                query = query.Where(x => x.Korisnik.BrojKartice == search.BrojKartice);
            }
            List<Model.PrisutnostClana> result = query.Where(x => x.VrijemeOdlaska == null).Select(x => new Model.PrisutnostClana
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

            return result;
        }
    }
}
