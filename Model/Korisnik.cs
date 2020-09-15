using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime? DatumRodenja { get; set; }
        public string Spol { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string BrojKartice { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Slika { get; set; }
        public ICollection<KorisniciUloge> KorisniciUloge { get; set; }

    }
}
