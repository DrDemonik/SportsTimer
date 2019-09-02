using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace SportsTimer
{
    public class RunningTime : INotifyPropertyChanged
    {
        private int _num;
        private TimeSpan _countMilisec;
        private string _textTimer;
        public int Num
        {
            get { return _num; }
            set
            {
                _num = value;
                OnPropertyChanged("Num");
            }
        }
        public TimeSpan CountMilisec
        {
            get { return _countMilisec; }
            set
            {
                _countMilisec = value;
                _textTimer= _countMilisec.ToString();                
                OnPropertyChanged("TextTimer");
            }
        }
        public string TextTimer
        {
            get { return _textTimer; }
        }

        public RunningTime()
        {
            CountMilisec = new TimeSpan();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
