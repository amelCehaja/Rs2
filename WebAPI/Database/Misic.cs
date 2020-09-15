using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class Misic
    {
        public Misic()
        {
            VjezbaMisic = new HashSet<VjezbaMisic>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<VjezbaMisic> VjezbaMisic { get; set; }
    }
}
