using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class PrisutnostClanaInsertRequest
    {
        public int KorisnikId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan VrijemeDolaska { get; set; }
    }
}
