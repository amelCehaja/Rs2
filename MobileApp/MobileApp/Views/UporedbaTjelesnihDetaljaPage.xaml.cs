using MobileApp.ViewModels;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UporedbaTjelesnihDetaljaPage : ContentPage
    {
        public UporedbaTjelesnihDetaljaViewModel model = null;
        public UporedbaTjelesnihDetaljaPage(TjelesniDetalji detaljiJedan, TjelesniDetalji detaljiDva)
        {
            InitializeComponent();
            BindingContext = model = new UporedbaTjelesnihDetaljaViewModel
            {
                DetaljiJedan = detaljiJedan,
                DetaljiDva = detaljiDva,
                TezinaWidth = getWidth(detaljiJedan.Tezina, detaljiDva.Tezina),
                TezinaDvaWidth = getWidth(detaljiDva.Tezina,detaljiJedan.Tezina),
                BicepsWidth = getWidth(detaljiJedan.ObimBicepsa,detaljiDva.ObimBicepsa),
                BicepsDvaWidth = getWidth(detaljiDva.ObimBicepsa,detaljiJedan.ObimBicepsa),
                NogaWidth = getWidth(detaljiJedan.ObimNoge,detaljiDva.ObimNoge),
                NogaDvaWidth = getWidth(detaljiDva.ObimNoge,detaljiJedan.ObimNoge),
                PrsaWidth = getWidth(detaljiJedan.ObimPrsa,detaljiDva.ObimPrsa),
                PrsaDvaWidth = getWidth(detaljiDva.ObimPrsa,detaljiJedan.ObimPrsa),
                StrukWidth = getWidth(detaljiJedan.ObimStruka,detaljiDva.ObimStruka),
                StrukDvaWidth = getWidth(detaljiDva.ObimStruka,detaljiJedan.ObimStruka)
            };

        }
        public double getWidth(double? num1, double? num2)
        {
            int maxWidth = 380;
            if (num1 == null && num2 == null)
                return maxWidth / 2;
            if (num1 == null)
                return 0;
            if (num2 == null)
                return 380;
            double y = num2 ?? default(double);
            double x = num1 ?? default(double);
            double percentage = x / (x+y);
            double _width =  maxWidth * percentage;
            return _width;
        }

    }
}