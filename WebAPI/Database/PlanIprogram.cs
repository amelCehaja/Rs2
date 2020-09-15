using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class PlanIprogram
    {
        public PlanIprogram()
        {
            Dan = new HashSet<Dan>();
            Komentar = new HashSet<Komentar>();
            KorisnikPlanIprogram = new HashSet<KorisnikPlanIprogram>();
            Ocjena = new HashSet<Ocjena>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double Cijena { get; set; }
        public int KategorijaId { get; set; }

        public PlanKategorija Kategorija { get; set; }
        public ICollection<Dan> Dan { get; set; }
        public ICollection<Komentar> Komentar { get; set; }
        public ICollection<KorisnikPlanIprogram> KorisnikPlanIprogram { get; set; }
        public ICollection<Ocjena> Ocjena { get; set; }
    }
}
