using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Requests;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommenderController : ControllerBase
    {
        private readonly IRecommender _service;
        public RecommenderController(IRecommender recommender)
        {
            _service = recommender;
        }
        [HttpGet]
        public Model.Recomender Get([FromQuery] RecommenderRequest request)
        {
            return _service.Get(request.TjelesniDetaljiId);
        }
    }
}
