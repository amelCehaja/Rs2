using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI.Database;

namespace WebAPI.Services
{
    public class ClanarinaService : BaseCRUDService<Model.Clanarina, ClanarinaSearchRequest, ClanarinaInsertRequest, Model.Clanarina, Database.Clanarina>
    {
        public ClanarinaService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Clanarina> Get(ClanarinaSearchRequest request)
        {
            List<Model.Clanarina> clanarine = new List<Model.Clanarina>();
            if (request.KorisnikId != null)
            {
                clanarine = _context.Clanarina
                                                    .Where(x => x.KorisnikId == request.KorisnikId)
                                                    .Select(x => new Model.Clanarina
                                                    {
                                                        Id = x.Id,
                                                        KorisnikId = x.KorisnikId,
                                                        DatumDodavanja = x.DatumDodavanja,
                                                        DatumIsteka = x.DatumIsteka,
                                                        TipClanarine = x.TipClanarine.Naziv + " - " + x.Cijena.ToString() + " KM"
                                                    })
                                                    .ToList();
            }
            else
            {
                clanarine = _context.Clanarina.Where(x => x.DatumDodavanja.Date > request.Od && x.DatumDodavanja < request.Do).Select(x => new Model.Clanarina
                {
                    Id = x.Id,
                    KorisnikId = x.KorisnikId,
                    DatumDodavanja = x.DatumDodavanja,
                    DatumIsteka = x.DatumIsteka,
                    TipClanarine = x.TipClanarine.Naziv + " - " + x.Cijena.ToString() + " KM",
                    Cijena = x.Cijena
                }).ToList();
            }
            return clanarine;
        }
    }
}
