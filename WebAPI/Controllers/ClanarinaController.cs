using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    public class ClanarinaController : BaseCRUDController<Model.Clanarina, ClanarinaSearchRequest, ClanarinaInsertRequest, Model.Clanarina>
    {
        public ClanarinaController(ICRUDService<Clanarina, ClanarinaSearchRequest, ClanarinaInsertRequest, Clanarina> service) : base(service)
        {
        }
    }
}