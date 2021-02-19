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
    public partial class PlanDetailsPage : ContentPage
    {
        private PlanDetailsViewModel _model = null;
        public PlanDetailsPage(PlanIProgram plan)
        {
            InitializeComponent();
            BindingContext = _model = new PlanDetailsViewModel()
            {
                PlanIProgram = plan
            };
        }
        protected async override void OnAppearing()
        {
            await _model.GetOcjene();
            await _model.ProvjeraPOsjedovanja();
            await _model.ProvjeraOcjene();
            base.OnAppearing();
        }
        
        public async void Ocijeni(object sender, EventArgs e)
        {
            int id = _model.PlanIProgram.Id;
            await Navigation.PushModalAsync(new OcjenaPage(id));
        }
        public async void Pitanja(object sender, EventArgs e)
        {
            int id = _model.PlanIProgram.Id;
            await Navigation.PushModalAsync(new KomentarPage(id));
        }
        public async void Kupi(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PlanKupovinaPage(_model.PlanIProgram));
        }
        public async void Pregled(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new DaniPage(_model.PlanIProgram));
        }
    }
}