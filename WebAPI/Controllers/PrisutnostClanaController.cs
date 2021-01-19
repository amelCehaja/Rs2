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
    [Authorize(Roles = "Administrator,Clan")]
    [Route("api/[controller]")]
    [ApiController]
    public class PrisutnostClanaController : BaseCRUDController<Model.PrisutnostClana, PrisutnostClanaSearchRequest, PrisutnostClanaInsertRequest, object>
    {
        public PrisutnostClanaController(ICRUDService<PrisutnostClana, PrisutnostClanaSearchRequest, PrisutnostClanaInsertRequest, object> service) : base(service)
        {      
        }
    }
}