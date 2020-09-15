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
    public partial class VjezbaDetailsPage : ContentPage
    {
        VjezbaDetailsViewModel model = null;
        public VjezbaDetailsPage(Vjezba vjezba)
        {
            InitializeComponent();
            BindingContext = model = new VjezbaDetailsViewModel
            {
                Vjezba = vjezba
            };
        }
    }
}