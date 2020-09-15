using Model;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels
{
    public class TjelesniNapredakListViewModel:BaseViewModel
    {
        private readonly APIService _tjelesniDetalji = new APIService("tjelesniDetalji");
        public TjelesniNapredakListViewModel()
        {

        }
        public ObservableCollection<TjelesniDetalji> Detalji { get; set; } = new ObservableCollection<TjelesniDetalji>();
        public TjelesniDetalji DetaljiJedan { get; set; }
        public TjelesniDetalji DetaljiDva { get; set; }
        public async Task LoadDetalji()
        {
            Detalji.Clear();
            TjelesniDetaljiSearchRequest request = new TjelesniDetaljiSearchRequest
            {
                KorisnikId = APIService.UserId
            };
            List<TjelesniDetalji> list = await _tjelesniDetalji.Get<List<TjelesniDetalji>>(request);
            if (list.Count > 0)
            {
                foreach(var x in list)
                {
                    x.DatumString = x.Datum.ToString("dd.MM.yyyy");
                    Detalji.Add(x);
                }
            }
        }
    }
}
