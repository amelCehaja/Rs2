using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class Clanarina
    {
        public int Id { get; set; }
        public DateTime DatumDodavanja { get; set; }
        public DateTime DatumIsteka { get; set; }
        public double Cijena { get; set; }
        public int KorisnikId { get; set; }
        public int TipClanarineId { get; set; }

        public Korisnik Korisnik { get; set; }
        public TipClanarine TipClanarine { get; set; }
    }
}
