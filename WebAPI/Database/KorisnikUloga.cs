using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class KorisnikUloga
    {
        public int Id { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }

        public Korisnik Korisnik { get; set; }
        public Uloga Uloga { get; set; }
    }
}
