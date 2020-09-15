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
    public class KomentarController : BaseCRUDController<Model.Komentar, KomentarSearchRequest, KomentarInsertRequest, object>
    {
        public KomentarController(ICRUDService<Komentar, KomentarSearchRequest, KomentarInsertRequest, object> service) : base(service)
        {
        }
    }
}
