using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TjelesniDetalji
    {
        public int Id { get; set; }
        public double? Tezina { get; set; }
        public double? ObimStruka { get; set; }
        public double? ObimBicepsa { get; set; }
        public double? ObimPrsa { get; set; }
        public double? ObimNoge { get; set; }
        public DateTime Datum { get; set; }
        public string DatumString { get; set; }
    }
}
