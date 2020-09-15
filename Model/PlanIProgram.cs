using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PlanIProgram
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double Cijena { get; set; }
        public string Kategorija { get; set; }
        public int KategorijaId { get; set; }
    }
}
