using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DanSet
    {
        public int Id { get; set; }
        public int DanId { get; set; }
        public int SetVjezbaId { get; set; }
        public int VjezbaId { get; set; }
        public int RedniBroj { get; set; }
        public string Vjezba { get; set; }
    }
}
