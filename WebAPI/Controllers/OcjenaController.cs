using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcjenaController : BaseCRUDController<Model.Ocjena, Model.Requests.OcjenaSearchRequest, Model.Requests.OcjenaInsertRequest, object>
    {
        public OcjenaController(ICRUDService<Ocjena, Model.Requests.OcjenaSearchRequest, Model.Requests.OcjenaInsertRequest, object> service) : base(service)
        {
        }
    }
}
