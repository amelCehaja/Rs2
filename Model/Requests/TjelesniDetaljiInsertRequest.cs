using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests
{
    public class TjelesniDetaljiInsertRequest
    {
        public double? Tezina { get; set; }
        public double? ObimStruka { get; set; }
        public double? ObimBicepsa { get; set; }
        public double? ObimPrsa { get; set; }
        public double? ObimNoge { get; set; }
        public DateTime Datum { get; set; }
        public int KorisnikId { get; set; }
    }
}
