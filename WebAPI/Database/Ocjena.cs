using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class Ocjena
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Opis { get; set; }
        public int PlanId { get; set; }
        public int KorisnikId { get; set; }
        public PlanIprogram Plan { get; set; }
        public Korisnik Korisnik { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan Vrijeme { get; set; }

    }
}
