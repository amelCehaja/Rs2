using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class IzvjestajClanovi
    {
        public List<Model.Clanarina> clanarine { get; set; }
        public Dani Dani { get; set; }
    }
    public class Dani
    {
        public int Ponedeljak { get; set; }
        public int Utorak { get; set; }
        public int Srijeda { get; set; }
        public int Cetvrtak { get; set; }
        public int Petak { get; set; }
        public int Subota { get; set; }
        public int Nedelja { get; set; }
    }
}
