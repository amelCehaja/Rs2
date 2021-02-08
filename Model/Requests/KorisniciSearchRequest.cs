using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class KorisniciSearchRequest
    {
        public int? Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string BrojKartice { get; set; }
        public string Username { get; set; }
        public string Uloga { get; set; }
    }
}
