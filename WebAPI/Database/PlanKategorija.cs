using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class PlanKategorija
    {
        public PlanKategorija()
        {
            PlanIprogram = new HashSet<PlanIprogram>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<PlanIprogram> PlanIprogram { get; set; }
    }
}
