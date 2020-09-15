using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Ocjena
    {
        public int ID { get; set; }
        public string KorisnikImePrezime { get; set; }        
        public int KorisnikId { get; set; }
        public int Rating { get; set; }
        public string Opis { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan Vrijeme{ get; set; }
        public string DatumVrijemeString { get; set; }
    }
}
