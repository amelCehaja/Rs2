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
    [Route("api/[controller]")]
    [ApiController]
    public class VjezbaController : BaseCRUDController<Model.Vjezba, VjezbaSearchRequest, VjezbaInsertRequest, VjezbaInsertRequest>
    {
        public VjezbaController(ICRUDService<Vjezba, VjezbaSearchRequest, VjezbaInsertRequest, VjezbaInsertRequest> service) : base(service)
        {
        }
    }
}