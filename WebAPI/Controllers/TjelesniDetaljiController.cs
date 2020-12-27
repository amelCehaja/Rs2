using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Requests;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TjelesniDetaljiController : BaseCRUDController<Model.TjelesniDetalji, TjelesniDetaljiSearchRequest, TjelesniDetaljiInsertRequest, object>
    {
        public TjelesniDetaljiController(ICRUDService<TjelesniDetalji, TjelesniDetaljiSearchRequest, TjelesniDetaljiInsertRequest, object> service) : base(service)
        {
        }
    }
}
