using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Clanarina = new HashSet<Clanarina>();
            KorisnikPlanIprogram = new HashSet<KorisnikPlanIprogram>();
            KorisnikUloga = new HashSet<KorisnikUloga>();
            PrisutnostClana = new HashSet<PrisutnostClana>();
            TjelesniDetalji = new HashSet<TjelesniDetalji>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime? DatumRodenja { get; set; }
        public string Spol { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string BrojKartice { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public byte[] Slika { get; set; }

        public ICollection<Clanarina> Clanarina { get; set; }
        public ICollection<KorisnikPlanIprogram> KorisnikPlanIprogram { get; set; }
        public ICollection<KorisnikUloga> KorisnikUloga { get; set; }
        public ICollection<PrisutnostClana> PrisutnostClana { get; set; }
        public ICollection<TjelesniDetalji> TjelesniDetalji { get; set; }
    }
}
