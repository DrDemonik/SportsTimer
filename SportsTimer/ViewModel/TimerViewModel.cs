using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Windows.Threading;
using System.Windows.Input;

namespace SportsTimer
{
    class TimerViewModel : INotifyPropertyChanged
    {

        private DispatcherTimer timer = null;
        private int stepInMs = 1000;

        private Timer _currentTime;

        public Timer CurrentTime
        {
            get { return _currentTime; }
            set
            {
                _currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }


        private string _textTimer;

        public string TextTimer
        {
            get { return _textTimer; }
            set
            {
                _textTimer = value;
                OnPropertyChanged("TextTimer");
            }
        }

        public ICommand StartCurrentTimer { get; set; }
        public ICommand StopCurrentTimer { get; set; }

        public TimerViewModel()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(stepInMs);
            timer.Tick += Timer_Tick;

            StartCurrentTimer = new RelayCommand(Start);
            StopCurrentTimer = new RelayCommand(Stop);

            CurrentTime = new Timer();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentTime.CountMilisec += stepInMs;
            TextTimer = TimeSpan.FromMilliseconds(CurrentTime.CountMilisec).ToString();
        }

        void Start()
        {
            timer?.Start();
        }

        void Stop()
        {
            timer?.Stop();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
