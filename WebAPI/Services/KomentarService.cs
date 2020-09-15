using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Requests;
using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;

namespace WebAPI.Services
{
    public class KomentarService : BaseCRUDService<Model.Komentar, KomentarSearchRequest, KomentarInsertRequest, object, Database.Komentar>
    {
        public KomentarService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Komentar> Get([FromQuery] KomentarSearchRequest search)
        {
            var komentari = _context.Komentar.Include(x => x.NadKomentar).Include(x => x.Korisnik).Where(x => x.PlanId == search.PlanId && x.NadKomentarId == null).ToList();
            List<Model.Komentar> data = new List<Model.Komentar>();
            foreach(var x in komentari)
            {
                var _komentar = _mapper.Map<Model.Komentar>(x);
                _komentar.NadKomentar = _mapper.Map<Model.Komentar>(_context.Komentar.Where(y => y.NadKomentarId == x.Id).SingleOrDefault());
                data.Add(_komentar);
            }
            return data;
        }
    }
}
