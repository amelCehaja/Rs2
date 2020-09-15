using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class PrisutnostClana
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan VrijemeDolaska { get; set; }
        public TimeSpan? VrijemeOdlaska { get; set; }
        public int KorisnikId { get; set; }

        public Korisnik Korisnik { get; set; }
    }
}
