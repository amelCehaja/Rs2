using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class PrisutnostClanaSearchRequest
    {
        public string BrojKartice { get; set; }
        public DateTime? Od { get; set; }
        public DateTime? Do { get; set; }
    }
}
