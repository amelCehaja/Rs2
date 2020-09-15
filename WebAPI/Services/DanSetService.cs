using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;

namespace WebAPI.Services
{
    public class DanSetService : BaseCRUDService<Model.DanSet, DanSetSearchRequest, DanSetInsertRequest, object, Database.DanSet>
    {
        public DanSetService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.DanSet> Get([FromQuery] DanSetSearchRequest search)
        {
            var list = _context.DanSet.Include(x => x.Vjezba).Where(x => x.DanId == search.DanId).OrderBy(x => x.RedniBroj).ToList();
            List<Model.DanSet> result = new List<Model.DanSet>();
            list.ForEach(x =>
            {
                Model.DanSet entity = _mapper.Map<Model.DanSet>(x);
                entity.Vjezba = x.Vjezba.Naziv;
                result.Add(entity);
            });
            return _mapper.Map<List<Model.DanSet>>(result);
        }
    }
}
