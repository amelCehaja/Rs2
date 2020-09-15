using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class SetVjezba
    {
        public int Id { get; set; }
        public int BrojPonavljanja { get; set; }
        public int RedniBroj { get; set; }
        public int? TrajanjeOdmora { get; set; }
        public int? DanSetId { get; set; }

        public DanSet DanSet { get; set; }
    }
}
