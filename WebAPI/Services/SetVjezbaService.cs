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
    public class SetVjezbaService : BaseCRUDService<Model.SetVjezba, SetVjezbaSearchRequest, SetVjezbaInsertRequest, object, Database.SetVjezba>
    {
        public SetVjezbaService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.SetVjezba> Get([FromQuery] SetVjezbaSearchRequest search)
        {
            var setVjezbe = _context.SetVjezba.Where(x => x.DanSetId == search.DanSetId).OrderBy(x => x.RedniBroj).ToList();
            List<Model.SetVjezba> list = _mapper.Map<List<Model.SetVjezba>>(setVjezbe);
            return _mapper.Map<List<Model.SetVjezba>>(setVjezbe);
        }
        public override Model.SetVjezba Insert(SetVjezbaInsertRequest request)
        {
            SetVjezba entity = new SetVjezba
            {
                DanSetId = request.DanSetId,
                BrojPonavljanja = request.BrojPonavljanja,
                TrajanjeOdmora = request.TrajanjeOdmora,
                RedniBroj = _context.SetVjezba.Where(x => x.DanSetId == request.DanSetId).Count() + 1
            };
            _context.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.SetVjezba>(entity);
        }
    }
}
