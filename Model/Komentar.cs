﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Komentar
    {
        public int KomentarId { get; set; }
        public string Opis { get; set; }
        public DateTime Datum { get; set; }
        public Komentar NadKomentar { get; set; }
        public int PlanId { get; set; }
        public Korisnik Korisnik { get; set; }
        public string ImePrezime { get; set; }
        public string DatumString { get; set; }
    }
}