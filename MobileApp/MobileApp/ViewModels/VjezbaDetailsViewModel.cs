using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.ViewModels
{
    public class VjezbaDetailsViewModel:BaseViewModel
    {
        public VjezbaDetailsViewModel()
        {

        }
        string _naziv = string.Empty;
        private Vjezba _vjezba;
        public Vjezba Vjezba
        {
            get { return _vjezba; }
            set { SetProperty(ref _vjezba, value); }
        }
        
        
    }
}
