using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Requests;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;

namespace WebAPI.Services
{
    public class OcjenaService : BaseCRUDService<Model.Ocjena, Model.Requests.OcjenaSearchRequest, OcjenaInsertRequest, object, Database.Ocjena>
    {
        public OcjenaService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Ocjena> Get([FromQuery] OcjenaSearchRequest request)
        {
            List<Model.Ocjena> ocjene = new List<Model.Ocjena>();
            if (request.KorisnikId == null)
            {
                ocjene = _context.Ocjena.Include(x => x.Korisnik).Where(x => x.PlanId == request.PlanId).Select(x => new Model.Ocjena
                {
                    ID = x.Id,
                    KorisnikId = x.KorisnikId,
                    KorisnikImePrezime = x.Korisnik.Ime + " " + x.Korisnik.Prezime,
                    Opis = x.Opis,
                    Rating = x.Rating,
                    Vrijeme = x.Vrijeme,
                    Datum = x.Datum
                }).OrderByDescending(x => x.Datum)
                .OrderByDescending(x => x.Vrijeme)
                .ToList();
            }
            else
            {
                ocjene = _context.Ocjena.Include(x => x.Korisnik).Where(x => x.PlanId == request.PlanId && x.KorisnikId == request.KorisnikId).Select(x => new Model.Ocjena
                {
                    ID = x.Id,
                    KorisnikId = x.KorisnikId,
                    KorisnikImePrezime = x.Korisnik.Ime + " " + x.Korisnik.Prezime,
                    Opis = x.Opis,
                    Rating = x.Rating,
                    Vrijeme = x.Vrijeme,
                    Datum = x.Datum
                }).OrderByDescending(x => x.Datum)
                .OrderByDescending(x => x.Vrijeme)
                .ToList();
            }
            return ocjene;
        }
}
}
