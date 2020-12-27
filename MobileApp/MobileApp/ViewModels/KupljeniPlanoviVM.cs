using Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class KupljeniPlanoviVM 
    {
        private readonly APIService _korisnikPlanervice = new APIService("KorisnikPlan");
        private readonly APIService _planService = new APIService("planIProgram");
        public KupljeniPlanoviVM()
        {
            InitCommand = new Command(async () => await LoadPlanove());
        }
        public ObservableCollection<Model.PlanIProgram> PlanoviList { get; set; } = new ObservableCollection<Model.PlanIProgram>();

        public ICommand InitCommand { get; set; }
        public async Task LoadPlanove()
        {
            PlanoviList.Clear();
            KorisnikPlanSearchRequest request = new KorisnikPlanSearchRequest
            {
                KorisnikId = APIService.UserId
            };
            List<Model.KorisnikPlan> korisnikPlanovi = await _korisnikPlanervice.Get<List<Model.KorisnikPlan>>(request);
            foreach(var x in korisnikPlanovi)
            {
                Model.PlanIProgram planIProgram = await _planService.GetById<Model.PlanIProgram>(x.PlanId);
                PlanoviList.Add(planIProgram);
            }

        }
    }
}
