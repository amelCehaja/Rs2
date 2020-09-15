using Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileApp.ViewModels
{
    public class TjelesniNapredakAddViewModel:BaseViewModel
    {
        private readonly APIService _tjelesniNapredakService = new APIService("tjelesniDetalji");
        public TjelesniNapredakAddViewModel()
        {

        }
        private double? _kilaza = null;
        public double? Kilaza
        {
            get { return _kilaza; }
            set { SetProperty(ref _kilaza, value); }
        }
        private double? _obimBicepsa = null;
        public double? ObimBicepsa
        {
            get { return _obimBicepsa; }
            set { SetProperty(ref _obimBicepsa, value); }
        }
        private double? _obimNoge = null;
        public double? ObimNoge
        {
            get { return _obimNoge; }
            set { SetProperty(ref _obimNoge, value); }
        }
        private double? _obimStruka = null;
        public double? ObimStruka
        {
            get { return _obimStruka; }
            set { SetProperty(ref _obimStruka, value); }
        }
        private double? _obimPrsa = null;
        public double? ObimPrsa
        {
            get { return _obimPrsa; }
            set { SetProperty(ref _obimPrsa, value); }
        }
        private double? _tezina = null;
        public double? Tezina
        {
            get { return _tezina; }
            set { SetProperty(ref _tezina, value); }
        }
        public async Task Spremi()
        {
            TjelesniDetaljiInsertRequest request = new TjelesniDetaljiInsertRequest
            {
                Datum = DateTime.Today,
                KorisnikId = APIService.UserId,
                ObimBicepsa = ObimBicepsa,
                ObimNoge = ObimNoge,
                ObimPrsa = ObimPrsa,
                ObimStruka = ObimStruka,
                Tezina = Tezina
            };
            await _tjelesniNapredakService.Insert<object>(request);
        }
    }
}
