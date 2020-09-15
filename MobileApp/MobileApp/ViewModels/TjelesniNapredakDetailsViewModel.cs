using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.ViewModels
{
    public class TjelesniNapredakDetailsViewModel:BaseViewModel
    {
        public TjelesniNapredakDetailsViewModel()
        {

        }
        private TjelesniDetalji _detalji = null;
        public TjelesniDetalji Detalji {
            get { return _detalji; }
            set { SetProperty(ref _detalji, value); }
        }
    }
}
