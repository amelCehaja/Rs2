using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class Vjezba
    {
        public Vjezba()
        {
            DanSet = new HashSet<DanSet>();
            VjezbaMisic = new HashSet<VjezbaMisic>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Gif { get; set; }

        public ICollection<DanSet> DanSet { get; set; }
        public ICollection<VjezbaMisic> VjezbaMisic { get; set; }
    }
}
