using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class Uloga
    {
        public Uloga()
        {
            KorisnikUloga = new HashSet<KorisnikUloga>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public ICollection<KorisnikUloga> KorisnikUloga { get; set; }
    }
}
