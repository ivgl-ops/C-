using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Domain
{
    public class Teacher : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get 
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        private string midname;
        public string Midname
        {
            get
            {
                return midname;
            }
            set
            {
                midname = value;
                OnPropertyChanged("Midname");
            }
        }
        private Institute univer;
        public Institute Univer
        {
            get
            {
                return univer;
            }
            set
            {
                univer = value;
                OnPropertyChanged("Univer");
            }
        }
        private Service serv;
        public Service Serv
        {
            get
            {
                return serv;
            }
            set
            {
                serv = value;
                OnPropertyChanged("Serv");
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
