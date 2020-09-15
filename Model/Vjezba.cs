using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Vjezba
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Gif { get; set; }
        public List<String> Misici { get; set; }
        public String MisiciString { get; set; }
    }
}
