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
    public class TjelesniDetaljiService : BaseCRUDService<Model.TjelesniDetalji, TjelesniDetaljiSearchRequest, TjelesniDetaljiInsertRequest, object, Database.TjelesniDetalji>
    {
        public TjelesniDetaljiService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.TjelesniDetalji> Get([FromQuery] TjelesniDetaljiSearchRequest search)
        {

            var list = _context.TjelesniDetalji.Where(x => x.KorisnikId == search.KorisnikId).OrderByDescending(x => x.Datum).ToList();
            return _mapper.Map<List<Model.TjelesniDetalji>>(list);
        }
    }
}
