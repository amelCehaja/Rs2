using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IClanarina
    {
        List<Model.Clanarina> GetByClanId(int clanId);
    }
}
