using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface ITipClanarine
    {
        List<TipClanarine> Get();
        TipClanarine GetByID(int id);
    }
}
