using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PrisutnostClana
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan VrijemeDolaska { get; set; }
        public TimeSpan? VrijemeOdlaska { get; set; }
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool Aktivan { get; set; }
        public string TipClanarine { get; set; }
        public string VrijediDo { get; set; }
        public byte[] Slika { get; set; }
    }
}
