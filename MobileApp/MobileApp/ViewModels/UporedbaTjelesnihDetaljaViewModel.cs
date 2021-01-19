using Model;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace MobileApp.ViewModels
{
    public class UporedbaTjelesnihDetaljaViewModel:BaseViewModel
    {
        public UporedbaTjelesnihDetaljaViewModel()
        {

        } 
        public TjelesniDetalji DetaljiJedan { get; set; }
        public TjelesniDetalji DetaljiDva { get; set; }
        public double TezinaWidth { get; set; }
        public double TezinaDvaWidth { get; set; }
        public double StrukWidth { get; set; }
        public double StrukDvaWidth { get; set; }
        public double PrsaWidth { get; set; }
        public double PrsaDvaWidth { get; set; }
        public double NogaWidth { get; set; }
        public double NogaDvaWidth { get; set; }
        public double BicepsWidth { get; set; }
        public double BicepsDvaWidth { get; set; }
        public string DatumJedan { get; set; }
        public string DatumDva { get; set; }

    }
}
