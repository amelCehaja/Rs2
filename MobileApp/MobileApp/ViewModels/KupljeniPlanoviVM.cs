using Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels
{
    public class KupljeniPlanoviVM 
    {
        private readonly APIService _korisnikPlanervice = new APIService("KorisnikPlan");
        private readonly APIService _planService = new APIService("planIProgram");
        public KupljeniPlanoviVM()
        {

        }
        public List<Model.PlanIProgram> PlanoviList { get; set; } = new List<Model.PlanIProgram>();

        public async Task LoadPlanove()
        {
            PlanoviList.Clear();
            PlanoviList = new List<Model.PlanIProgram>();
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
