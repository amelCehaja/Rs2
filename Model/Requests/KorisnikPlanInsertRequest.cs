using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class KorisnikPlanInsertRequest
    {
        public int KorisnikId { get; set; }
        public int PlanId { get; set; }
        public double Cijena { get; set; }
        public int TjelesniDetaljiId { get; set; }
        public DateTime DatumVrijemeKupovine { get; set; }
    }
}
