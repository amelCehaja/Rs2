using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class KorisnikPlanIprogram
    {
        public DateTime DatumVrijemeKupovine { get; set; }
        public double Cijena { get; set; }
        public int KorisnikId { get; set; }
        public int PlanId { get; set; }
        public int TjelesniDetaljiId { get; set; }

        public TjelesniDetalji TjelesniDetalji { get; set; }
        public Korisnik Korisnik { get; set; }
        public PlanIprogram Plan { get; set; }
    }
}
