using Model;
using Stripe.Radar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class LiveTreningOdmorViewModel : BaseViewModel
    {
        public LiveTreningOdmorViewModel()
        {

        }
        public ObservableCollection<SetVjezba> SetVjezbe { get; set; } = new ObservableCollection<SetVjezba>();
        private SetVjezba _setVjezba = new SetVjezba();
        public SetVjezba SetVjezba
        {
            get { return _setVjezba; }
            set { SetProperty(ref _setVjezba, value); }
        }
        private int _secondsElapsed;
        public int SecondsElapsed
        {
            get { return _secondsElapsed; }
            set { SetProperty(ref _secondsElapsed, value); }
        }
        private string _test = String.Empty;
        public string Test
        {
            get { return _test; }
            set { SetProperty(ref _test, value); }
        }
        private System.Timers.Timer _timer;
        public void Start()
        {
            SetVjezba = SetVjezbe[0];
            SecondsElapsed = SetVjezba.TrajanjeOdmora ?? default(Int32);
            

            _timer = new System.Timers.Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += OnTimedEvent;
            _timer.Enabled = true;
            
        }
        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            SecondsElapsed--;

            //Update visual representation here
            //Remember to do it on UI thread

            if (SecondsElapsed == 0)
            {
                _timer.Stop();
                Test = "Kraj odmora!";
            }
        }
        public void Kraj()
        {
            SetVjezbe.Remove(SetVjezba);
        }
    }
}
