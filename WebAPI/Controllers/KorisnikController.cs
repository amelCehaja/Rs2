using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Requests;
using WebAPI.Database;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _service;
        public KorisnikController(IKorisnikService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.Korisnik> Get([FromQuery]KorisniciSearchRequest request)
        {
            return _service.Get(request);
        }
        [Authorize]
        [HttpGet("{brojKartice}")]
        public Model.Korisnik GetByBrojKartice(string brojKartice)
        {
            return _service.GetByBrojKartice(brojKartice);
        }

        [HttpPost]
        public Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            return _service.Insert(request);
        }
        [Authorize]
        [HttpPut("{id}")]
        public Model.Korisnik Update(int id, [FromBody] KorisnikUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}