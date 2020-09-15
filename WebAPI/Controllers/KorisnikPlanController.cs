using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Requests;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikPlanController : BaseCRUDController<Model.KorisnikPlan, KorisnikPlanSearchRequest, KorisnikPlanInsertRequest, object>
    {
        public KorisnikPlanController(ICRUDService<KorisnikPlan, KorisnikPlanSearchRequest, KorisnikPlanInsertRequest, object> service) : base(service)
        {
        }
    }
}
