using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class SetVjezbaInsertRequest
    {
        public int? DanSetId { get; set; }
        public int? TrajanjeOdmora { get; set; }
        public int BrojPonavljanja { get; set; }
    }
}
