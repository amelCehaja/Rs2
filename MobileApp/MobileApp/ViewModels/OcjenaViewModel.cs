using MobileApp.Views;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileApp.ViewModels
{
    public class OcjenaViewModel:BaseViewModel
    {
        private readonly APIService _ocjenaService = new APIService("Ocjena");
        public OcjenaViewModel() { }
        int _planId;
        public int PlanId
        {
            get { return _planId; }
            set { SetProperty(ref _planId, value); }
        }
        int _rating;
        public int Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }
        string _komentar = string.Empty;
        public string Komentar
        {
            get { return _komentar; }
            set { SetProperty(ref _komentar, value); }
        }
        public async Task _ocijeni()
        {
            OcjenaInsertRequest request = new OcjenaInsertRequest
            {
                PlanId = _planId,
                Opis = _komentar,
                Rating = _rating,
                KorisnikId = APIService.UserId
            };
            await _ocjenaService.Insert<object>(request);
        }
    }
}
