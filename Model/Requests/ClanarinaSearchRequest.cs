using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class ClanarinaSearchRequest
    {
        public int? KorisnikId { get; set; }
        public DateTime? Do { get; set; }
        public DateTime? Od { get; set; }
    }
}
