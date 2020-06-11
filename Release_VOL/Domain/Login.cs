using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Domain
{
    public class Login : INotifyPropertyChanged
    {
        private string log;
        public string Log
        {
            get
            {
                return log;
            }
            set
            {
                log = value;
                OnPropertyChanged("Log");
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
