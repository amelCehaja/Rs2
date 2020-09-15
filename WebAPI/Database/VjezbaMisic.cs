using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class VjezbaMisic
    {
        public int VjezbaId { get; set; }
        public int MisicId { get; set; }

        public Misic Misic { get; set; }
        public Vjezba Vjezba { get; set; }
    }
}
