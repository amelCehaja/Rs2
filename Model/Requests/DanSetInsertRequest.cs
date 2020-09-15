using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class DanSetInsertRequest
    {
        public int DanId { get; set; }
        public int VjezbaId { get; set; }
        public int RedniBroj { get; set; }
    }
}
