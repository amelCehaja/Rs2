using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class KomentarInsertRequest
    {
        public string Opis { get; set; }
        public DateTime Datum { get; set; }
        public int KorisnikId { get; set; }
        public int PlanId { get; set; }
        public int? NadkomentarId { get; set; }
    }
}
