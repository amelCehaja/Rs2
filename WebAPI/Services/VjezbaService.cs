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
    public class VjezbaService : BaseCRUDService<Model.Vjezba, VjezbaSearchRequest, VjezbaInsertRequest, VjezbaInsertRequest, Database.Vjezba>
    {
        public VjezbaService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override Model.Vjezba Insert(VjezbaInsertRequest request)
        {
            Database.Vjezba vjezba = _mapper.Map<Database.Vjezba>(request);
            _context.Add(vjezba);
            _context.SaveChanges();

            request.Misici.ForEach(x =>
            {
                Database.VjezbaMisic entity = new Database.VjezbaMisic
                {
                    VjezbaId = vjezba.Id,
                    MisicId = _context.Misic.Where(y => y.Naziv == x).Select(y => y.Id).FirstOrDefault()
                };
                _context.Add(entity);
                _context.SaveChanges();
            });

            Model.Vjezba model = _mapper.Map<Model.Vjezba>(vjezba);
            return model;
        }
        public override List<Model.Vjezba> Get([FromQuery] VjezbaSearchRequest search)
        {
            var query = _context.Set<Vjezba>().AsQueryable();
            if(search.Naziv != null)
            {
                query = query.Where(x => x.Naziv == search.Naziv);
            }

            List<Database.Vjezba> vjezbe = query.ToList();
            List<Model.Vjezba> result = new List<Model.Vjezba>();
            vjezbe.ForEach(x =>
            {
                Model.Vjezba vjezba = _mapper.Map<Model.Vjezba>(x);
                if (search.Misic == null)
                {
                    vjezba.Misici = _context.VjezbaMisic.Where(y => y.VjezbaId == x.Id).Select(y => y.Misic.Naziv).ToList();
                    vjezba.MisiciString = string.Join(",", vjezba.Misici);
                    result.Add(vjezba);
                }
                else
                {
                    vjezba.Misici = _context.VjezbaMisic.Where(y => y.VjezbaId == x.Id && y.Misic.Naziv == search.Misic).Select(y => y.Misic.Naziv).ToList();
                    vjezba.MisiciString = string.Join(",", vjezba.Misici);
                    foreach (var y in vjezba.Misici)
                    {
                        if (y == search.Misic)
                        {
                            result.Add(vjezba);
                            break;
                        }
                    }
                }
            });

            return result;
        }
        public override Model.Vjezba GetByID(int id)
        {
            Database.Vjezba vjezba = _context.Vjezba.Find(id);
            Model.Vjezba result = _mapper.Map<Model.Vjezba>(vjezba);
            result.Misici = new List<string>();
            List<Database.VjezbaMisic> list = _context.VjezbaMisic.Include(x => x.Misic).Where(x => x.VjezbaId == id).ToList();
            list.ForEach(x =>
            {
                result.Misici.Add(x.Misic.Naziv);
            });
            return result;
        }
        public override Model.Vjezba Update(int id, VjezbaInsertRequest request)
        {
            Vjezba vjezba = _context.Vjezba.Find(id);
            _mapper.Map(request, vjezba);
            List<VjezbaMisic> vjezbaMisicList = _context.VjezbaMisic.Include(x => x.Misic).Where(x => x.VjezbaId == id).ToList();
            vjezbaMisicList.ForEach(x =>
            {
                bool temp = false;
                foreach (var m in request.Misici)
                {
                    if (m == x.Misic.Naziv)
                    {
                        temp = true;
                        break;
                    }
                }
                if (temp == false)
                    _context.Remove(x);
            });
            request.Misici.ForEach(x =>
            {
                int count = _context.VjezbaMisic.Where(y => y.Misic.Naziv == x && y.VjezbaId == id).Count();
                if (count == 0)
                {
                    VjezbaMisic vjezbaMisic = new VjezbaMisic
                    {
                        VjezbaId = id,
                        MisicId = _context.Misic.Where(y => y.Naziv == x).Select(y => y.Id).FirstOrDefault()
                    };
                    _context.Add(vjezbaMisic);
                }
            });
            _context.SaveChanges();
            Model.Vjezba entity = _mapper.Map<Model.Vjezba>(vjezba);
            return entity;
        }

    }
}

