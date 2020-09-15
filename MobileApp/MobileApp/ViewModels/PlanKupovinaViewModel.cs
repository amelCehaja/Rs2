using Model;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels
{
    public class PlanKupovinaViewModel
    {
        private readonly APIService _planKorisnikService = new APIService("KorisnikPlan");
        private readonly APIService _tjelesniDetaljiService = new APIService("TjelesniDetalji");
        public PlanKupovinaViewModel()
        {

        }
        public PlanIProgram PlanIProgram { get; set; } = new PlanIProgram();
        public string CreditCardNumber { get; set; }
        public int CCV { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public async Task Kupi()
        {
            KorisnikPlanInsertRequest request = new KorisnikPlanInsertRequest
            {
                KorisnikId = APIService.UserId,
                Cijena = PlanIProgram.Cijena,
                PlanId = PlanIProgram.Id,
                DatumVrijemeKupovine = DateTime.Now
            };
            TjelesniDetaljiSearchRequest detaljiSearchRequest = new TjelesniDetaljiSearchRequest
            {
                KorisnikId = APIService.UserId
            };
            List<TjelesniDetalji> detalji = await _tjelesniDetaljiService.Get<List<TjelesniDetalji>>(detaljiSearchRequest);
            request.TjelesniDetaljiId = detalji[0].Id;

            await _planKorisnikService.Insert<object>(request);
        }
    }
}
