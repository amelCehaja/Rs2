using AutoMapper;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;

namespace WebAPI.Services
{
    public class PlanKategorijaService : BaseCRUDService<Model.PlanKategorija, object, PlanKategorijaInsertRequest, object, Database.PlanKategorija>
    {
        public PlanKategorijaService(RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
