using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;

namespace WebAPI
{
    public class SetupService
    {
        public static void Init(RS2Context rS2Context)
        {
            rS2Context.Database.Migrate();
        }
    }
}
