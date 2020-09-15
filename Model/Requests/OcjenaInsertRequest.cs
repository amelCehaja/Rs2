using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class OcjenaInsertRequest
    {
        public int KorisnikId { get; set; }
        public int PlanId { get; set; }
        public string Opis { get; set; }
        public int Rating { get; set; }
    }
}
