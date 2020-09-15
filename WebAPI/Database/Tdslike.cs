using System;
using System.Collections.Generic;

namespace WebAPI.Database
{
    public partial class Tdslike
    {
        public int Id { get; set; }
        public int TjelesniDetaljiId { get; set; }

        public TjelesniDetalji TjelesniDetalji { get; set; }
    }
}
