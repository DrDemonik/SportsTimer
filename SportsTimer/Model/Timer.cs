using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace SportsTimer
{
    class Timer : INotifyPropertyChanged
    {
        private int _num;
        private int _countMilisec;
        public int Num
        {
            get { return _num; }
            set
            {
                _num = value;
                OnPropertyChanged("Num");
            }
        }
        public int CountMilisec
        {
            get { return _countMilisec; }
            set
            {
                _countMilisec = value;
                OnPropertyChanged("Delta");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
