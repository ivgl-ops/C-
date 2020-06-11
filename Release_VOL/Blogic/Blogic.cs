using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Domain;

namespace Blogic
{
    public class Blogical : INotifyPropertyChanged
    {
        public ObservableCollection<Login> Logins { set; get; }


        public string LogName { get; set; }

        private Login newLog;
        public Login NewLog
        {
            get
            {
                return newLog;
            }
            set
            {
                newLog = value;
                OnPropertyChanged("NewLog");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public Blogical()
        {
            Logins = new ObservableCollection<Login>
            {
                new Login {Log = "wed" }
            };
        }

        private ICommand addCommand;
        public ICommand AddCommand => addCommand ?? (addCommand = new RelayCommand(AddTeacher));
        // Добавить extension methots//
        //--------------------------//
        //-------------------------//
        // Добавить methods-------//    
        public void AddTeacher()
        {
            Login teacher = new Login() { Log = LogName };
            Logins.Insert(0, teacher);
            NewLog = teacher;
        }
        


    }
}
