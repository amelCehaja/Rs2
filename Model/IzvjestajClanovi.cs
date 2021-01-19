using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class IzvjestajClanovi
    {
        public List<ClanarineIzvjestaj> clanarineIzvjestaj { get; set; }
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
    public class ClanarineIzvjestaj
    {
        public string Kategorija { get; set; }
        public int BrojClanarina { get; set; }
        public double Zarada { get; set; }
    }
}
