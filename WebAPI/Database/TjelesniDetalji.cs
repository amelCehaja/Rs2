using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class TjelesniDetalji
    {
        public TjelesniDetalji()
        {
            Tdslike = new HashSet<Tdslike>();
        }

        public int Id { get; set; }
        public double? Tezina { get; set; }
        public double? ObimStruka { get; set; }
        public double? ObimBicepsa { get; set; }
        public double? ObimPrsa { get; set; }
        public double? ObimNoge { get; set; }
        public DateTime Datum { get; set; }
        public int KorisnikId { get; set; }

        public Korisnik Korisnik { get; set; }
        public ICollection<Tdslike> Tdslike { get; set; }
    }
}
