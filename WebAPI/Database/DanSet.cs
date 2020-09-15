using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class DanSet
    {
        public DanSet()
        {
            SetVjezba = new HashSet<SetVjezba>();
        }

        public int Id { get; set; }
        public int DanId { get; set; }
        public int VjezbaId { get; set; }
        public int RedniBroj { get; set; }

        public Dan Dan { get; set; }
        public Vjezba Vjezba { get; set; }
        public ICollection<SetVjezba> SetVjezba { get; set; }
    }
}
