using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class Komentar
    {
        public Komentar()
        {
            InverseNadKomentar = new HashSet<Komentar>();
        }

        public int Id { get; set; }
        public string Opis { get; set; }
        public int? NadKomentarId { get; set; }
        public int PlanId { get; set; }
        public DateTime Datum { get; set; }
        public int KorisnikId { get; set; }

        public Korisnik Korisnik { get; set; }
        public Komentar NadKomentar { get; set; }
        public PlanIprogram Plan { get; set; }
        public ICollection<Komentar> InverseNadKomentar { get; set; }
    }
}
