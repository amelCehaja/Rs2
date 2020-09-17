using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class KorisnikPlanSearchRequest
    {
        public int PlanId { get; set; }
        public int? KorisnikId { get; set; }
    }
}
