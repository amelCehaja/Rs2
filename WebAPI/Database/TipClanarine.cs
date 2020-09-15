using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class TipClanarine
    {
        public TipClanarine()
        {
            Clanarina = new HashSet<Clanarina>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public int Trajanje { get; set; }

        public ICollection<Clanarina> Clanarina { get; set; }
    }
}
