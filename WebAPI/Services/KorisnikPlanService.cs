using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;

namespace WebAPI.Services
{
    public class KorisnikPlanService : BaseCRUDService<Model.KorisnikPlan, KorisnikPlanSearchRequest, KorisnikPlanInsertRequest, object, Database.KorisnikPlanIprogram>
    {
        public KorisnikPlanService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<KorisnikPlan> Get([FromQuery] KorisnikPlanSearchRequest search)
        {
            List<KorisnikPlanIprogram> list = new List<KorisnikPlanIprogram>();
            if(search.KorisnikId == null)
            {
                list = _context.KorisnikPlanIprogram.Where(x => x.PlanId == search.PlanId).ToList();
            }else 
                list = _context.KorisnikPlanIprogram.Where(x => x.KorisnikId == search.KorisnikId && x.PlanId == search.PlanId).ToList();
            return _mapper.Map<List<Model.KorisnikPlan>>(list);
        }
    }
}
