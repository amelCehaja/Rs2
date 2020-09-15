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
    public class TipClanarineService : BaseCRUDService<Model.TipClanarine, TipClanarineSearchRequest, TipClanarineInsertRequest, TipClanarineInsertRequest, TipClanarine>
    {
        public TipClanarineService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.TipClanarine> Get([FromQuery] TipClanarineSearchRequest search)
        {
            var list = _context.TipClanarine.AsQueryable();
            if (search.Naziv != null)
            {
                list.Where(x => search.Naziv == x.Naziv).ToList();
            }
            return _mapper.Map<List<Model.TipClanarine>>(list);
        }
    }
}
