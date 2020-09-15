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
    public class MisicService : BaseCRUDService<Model.Misic, MisicSearchRequest, MisicInsertRequest, Model.Misic, Database.Misic>
    {
        public MisicService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Misic> Get([FromQuery] MisicSearchRequest search)
        {
            var query = _context.Set<Misic>().AsQueryable();
            if(search.Naziv != null)
            {
                query.Where(x => x.Naziv == search.Naziv);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Misic>>(list);
        }
    }
}
