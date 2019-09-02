using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Windows.Threading;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace SportsTimer
{
    public class TimerViewModel 
    {        
        private DispatcherTimer timer = null;
        private int stepInMs = 50;

        private RunningTime _currentTime;

        public RunningTime CurrentTime
        {
            get { return _currentTime; }
            set
            {
                _currentTime = value;
            }
        }

        private ObservableCollection<RunningTime> _runningTimes;

        public ObservableCollection<RunningTime> RunningTimes
        {
            get { return _runningTimes; }
            set
            {
                _runningTimes = value;
            }
        }

        public ICommand StartCurrentTimer { get; set; }
        public ICommand StopCurrentTimer { get; set; }
        public ICommand DeleteAllTimer { get; set; }
        public ICommand AddPointInList { get; set; }


        DateTime Before;

        public TimerViewModel()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(stepInMs);
            timer.Tick += Timer_Tick;

            StartCurrentTimer = new RelayCommand(Start);
            StopCurrentTimer = new RelayCommand(Stop);
            DeleteAllTimer = new RelayCommand(Delete);
            AddPointInList = new RelayCommand(AddPoint);

            CurrentTime = new RunningTime();
            RunningTimes = new ObservableCollection<RunningTime>();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentTime.CountMilisec +=  DateTime.UtcNow.Subtract(Before);
            Before = DateTime.UtcNow;
        }

        void Start()
        {
            Before = DateTime.UtcNow;
            timer?.Start();            
        }

        void Stop()
        {
            timer?.Stop();
        }

        void Delete()
        {
            timer?.Stop();
            CurrentTime = new RunningTime();
            RunningTimes = new ObservableCollection<RunningTime>();
        }

        void AddPoint()
        {
            RunningTimes.Add(new RunningTime() { CountMilisec = CurrentTime.CountMilisec, Num = RunningTimes.Count + 1 });
        }
    }
}
