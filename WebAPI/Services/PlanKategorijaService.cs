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
    public class PlanKategorijaService : BaseCRUDService<Model.PlanKategorija, PlanKategorijaSearchRequest, PlanKategorijaInsertRequest, Model.PlanKategorija, Database.PlanKategorija>
    {
        public PlanKategorijaService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.PlanKategorija> Get([FromQuery] PlanKategorijaSearchRequest search)
        {
            var query = _context.Set<PlanKategorija>().AsQueryable();
            if(search.Naziv != null)
            {
                query.Where(x => x.Naziv == search.Naziv);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.PlanKategorija>>(list);
        }
    }
}
