using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public partial class KorisniciUloge
    {
        public int KorisnikUlogaId { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }
        public DateTime DatumIzmjene { get; set; }

        public Korisnik Korisnik { get; set; }
        public Uloge Uloga { get; set; }
    }
}
