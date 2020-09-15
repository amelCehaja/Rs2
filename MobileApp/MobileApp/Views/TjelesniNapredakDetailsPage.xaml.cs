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
    public partial class TjelesniNapredakDetailsPage : ContentPage
    {
        TjelesniNapredakDetailsViewModel model = null;
        public TjelesniNapredakDetailsPage(TjelesniDetalji detalji)
        {
            InitializeComponent();
            BindingContext = model = new TjelesniNapredakDetailsViewModel
            {
                Detalji = detalji
            };
        }
    }
}