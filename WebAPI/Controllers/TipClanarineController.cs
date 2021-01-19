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
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipClanarineController : BaseCRUDController<TipClanarine, TipClanarineSearchRequest, TipClanarineInsertRequest, TipClanarineInsertRequest>
    {
        public TipClanarineController(ICRUDService<TipClanarine, TipClanarineSearchRequest, TipClanarineInsertRequest, TipClanarineInsertRequest> service) : base(service)
        {
        }
    }
}