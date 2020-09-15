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
    public class DanService : BaseCRUDService<Model.Dan, DanSearchRequest, DanInsertRequest, object, Database.Dan>
    {
        public DanService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Dan> Get([FromQuery] DanSearchRequest search)
        {
            var dani = _context.Set<Dan>().AsQueryable();
            dani = dani.Where(x => x.PlanIprogramId == search.PlanIProgramId);
            List<Model.Dan> result = _mapper.Map<List<Model.Dan>>(dani.ToList());
            return result;
        }
        public override Model.Dan Insert(DanInsertRequest request)
        {
            Database.Dan dan = new Database.Dan
            {
                PlanIprogramId = request.PlanIProgramId,
                RedniBroj = _context.Dan.Where(x => x.PlanIprogramId == request.PlanIProgramId).Count() + 1
            };
            _context.Add(dan);
            _context.SaveChanges();
            return _mapper.Map<Model.Dan>(dan);
        }
    }
}
