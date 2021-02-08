using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class PlanIProgramUpdateRequest
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public int KategorijaId { get; set; }
        public string Opis { get; set; }
    }
}
