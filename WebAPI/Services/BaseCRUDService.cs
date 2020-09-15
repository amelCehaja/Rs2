using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI.Database;

namespace WebAPI.Services
{
    public class BaseCRUDService<T, TSearch, TInsert, TUpdate, TDb> : BaseService<T, TSearch, TDb>, ICRUDService<T, TSearch, TInsert, TUpdate> where TDb : class
    {
        public BaseCRUDService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual T Insert(TInsert request)
        {
            var entity = _mapper.Map<TDb>(request);
            _context.Add(entity);

            _context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public virtual T Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDb>().Find(id);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public virtual HttpResponseMessage Delete(int id)
        {
            var entity = _context.Set<TDb>().Find(id);
            if (entity == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            _context.Remove(entity);
            _context.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
