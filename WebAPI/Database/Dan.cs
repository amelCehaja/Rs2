using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class Dan
    {
        public Dan()
        {
            DanSet = new HashSet<DanSet>();
        }

        public int Id { get; set; }
        public int RedniBroj { get; set; }
        public int? PlanIprogramId { get; set; }

        public PlanIprogram PlanIprogram { get; set; }
        public ICollection<DanSet> DanSet { get; set; }
    }
}
