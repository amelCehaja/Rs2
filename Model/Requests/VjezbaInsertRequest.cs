using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class VjezbaInsertRequest
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Gif { get; set; }
        public List<string> Misici { get; set; }
    }
}
