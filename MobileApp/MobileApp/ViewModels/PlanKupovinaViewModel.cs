using Model;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

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
        public string CCV { get; set; }
        public string ExpMonth { get; set; }
        public string ExpYear { get; set; }
        public async Task Kupi()
        {
            if (string.IsNullOrEmpty(CreditCardNumber))
            {
                await Application.Current.MainPage.DisplayAlert("", "Broj kartice je obavezan!","OK");
                return;
            }else if (!Regex.Match(CreditCardNumber, @"^[0-9]+$", RegexOptions.IgnoreCase).Success)
            {
                await Application.Current.MainPage.DisplayAlert("", "Kreditna kartica moze sadrzavati samo brojeve!", "OK");
                return;
            }
            else if(CreditCardNumber.Length != 16)
            {
                await Application.Current.MainPage.DisplayAlert("", "Broj kartice mora biti 16 brojeva!", "OK");
                return;
            }
            if (string.IsNullOrEmpty(CCV)){
                await Application.Current.MainPage.DisplayAlert("", "CCV je obavezan!", "OK");
                return;
            }
            else if(!Regex.Match(CCV, @"^[0-9]+$", RegexOptions.IgnoreCase).Success && CCV.Length != 3)
            {
                await Application.Current.MainPage.DisplayAlert("", "CCV mora sadrzavati 3 broja!", "OK");
                return;
            }
            if (string.IsNullOrEmpty(ExpYear))
            {
                await Application.Current.MainPage.DisplayAlert("", "Godian je obavezna!", "OK");
                return;
            }else if(!Regex.Match(CCV, @"^[0-9]+$", RegexOptions.IgnoreCase).Success && CCV.Length != 4)
            {
                await Application.Current.MainPage.DisplayAlert("", "Godina mora sadrzavati 4 broja!", "OK");
                return;
            }
            if (string.IsNullOrEmpty(ExpYear))
            {
                await Application.Current.MainPage.DisplayAlert("", "Mjesec je obavezan!", "OK");
                return;
            }
            else if (!Regex.Match(CCV, @"^[0-9]+$", RegexOptions.IgnoreCase).Success && Int32.Parse(CCV) > 0 && Int32.Parse(CCV) < 13  )
            {
                await Application.Current.MainPage.DisplayAlert("", "Mjesec mogu biti samo brojevi od 1 do 12!", "OK");
                return;
            }
            DateTime datum = new DateTime(Int32.Parse(ExpYear), Int32.Parse(ExpMonth), 28);
            if(DateTime.Today > datum)
            {
                await Application.Current.MainPage.DisplayAlert("", "Kartica je istekla!", "OK");
                return;
            }

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
