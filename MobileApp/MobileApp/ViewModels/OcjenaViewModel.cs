using MobileApp.Views;
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
    public class OcjenaViewModel:BaseViewModel
    {
        private readonly APIService _ocjenaService = new APIService("Ocjena");
        public OcjenaViewModel() { }

        public class _ocjena
        {
            public int Ocjena { get; set; }
        }
        public ObservableCollection<_ocjena> Ocjene { get; set; } = new ObservableCollection<_ocjena>();

        int _planId;
        public int PlanId
        {
            get { return _planId; }
            set { SetProperty(ref _planId, value); }
        }
        _ocjena _rating;
        public _ocjena Rating
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
        public async Task<bool> _ocijeni()
        {
            if (_rating != null)
            {
                OcjenaInsertRequest request = new OcjenaInsertRequest
                {
                    PlanId = _planId,
                    Opis = _komentar,
                    Rating = _rating.Ocjena,
                    KorisnikId = APIService.UserId,
                    Datum = DateTime.Today,
                    Vrijeme = DateTime.Now.TimeOfDay
                };
                await _ocjenaService.Insert<object>(request);
                return true;
            }
            else 
            {
                await Application.Current.MainPage.DisplayAlert("", "Odaberite ocjenu!", "OK");
                return false;
            }
        }
        public void _loadOcjene()
        {
            for(int i =1; i < 6; i++)
            {
                _ocjena ocjena = new _ocjena
                {
                    Ocjena = i
                };
                Ocjene.Add(ocjena);
            }
        }
    }
}
