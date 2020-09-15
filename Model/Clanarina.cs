using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Clanarina
    {
        public int Id { get; set; }
        public DateTime DatumDodavanja { get; set; }
        public DateTime DatumIsteka { get; set; }
        public double Cijena { get; set; }
        public int KorisnikId { get; set; }
        public string TipClanarine { get; set; }
    }
}
