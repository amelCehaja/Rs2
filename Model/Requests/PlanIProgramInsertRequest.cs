using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class PlanIProgramInsertRequest
    {
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public int KategorijaId { get; set; }
        public string Opis { get; set; }
    }
}
