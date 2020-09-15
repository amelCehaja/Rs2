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
    public class PlanIProgramService : BaseCRUDService<Model.PlanIProgram, PlanIProgramSearchRequest, PlanIProgramInsertRequest, object, Database.PlanIprogram>
    {
        public PlanIProgramService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.PlanIProgram> Get([FromQuery] PlanIProgramSearchRequest search)
        {
            var planovi = _context.Set<PlanIprogram>().Include(x => x.Kategorija).AsQueryable();
            if (!string.IsNullOrWhiteSpace(search.Naziv))
                planovi = planovi.Where(x => x.Naziv.Contains(search.Naziv));
            var planoviList = planovi.ToList();
            List<Model.PlanIProgram> result = new List<Model.PlanIProgram>();
            planoviList.ForEach(x =>
            {
                Model.PlanIProgram planIProgram = _mapper.Map<Model.PlanIProgram>(x);
                planIProgram.Kategorija = x.Kategorija.Naziv;
                result.Add(planIProgram);
            });
            return result;
        }
    }
}
