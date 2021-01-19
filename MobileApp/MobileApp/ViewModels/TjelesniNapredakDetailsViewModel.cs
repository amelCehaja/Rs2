using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels
{
    public class TjelesniNapredakDetailsViewModel:BaseViewModel
    {
        private APIService _service = new APIService("TjelesniDetalji");
        public TjelesniNapredakDetailsViewModel()
        {

        }
        private TjelesniDetalji _detalji = null;
        public TjelesniDetalji Detalji {
            get { return _detalji; }
            set { SetProperty(ref _detalji, value); }
        }
        public async Task Obrisi()
        {
            await _service.Delete<Model.TjelesniDetalji>(Detalji.Id);
            return;
        }
    }
}
