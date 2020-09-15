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
    public class DanController : BaseCRUDController<Model.Dan, DanSearchRequest, DanInsertRequest, object>
    {
        public DanController(ICRUDService<Dan, DanSearchRequest, DanInsertRequest, object> service) : base(service)
        {
        }
    }
}