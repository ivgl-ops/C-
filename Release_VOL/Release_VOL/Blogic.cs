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
using Release_VOL;

namespace Blogic
{
    public class Blogical : INotifyPropertyChanged
    {
        public ObservableCollection<Login> Logins { set; get; }
        public ObservableCollection<User> Users { get; set; }
        public string NewName { get; set; }
        public string NewUsrNmbr { get; set; }
        public string LogName { get; set; }

        private User newuser;
        public User NewUser
        {
            get
            {
                return newuser;
            }
            set
            {
                newuser = value;
                OnPropertyChanged("NewUser");
            }
        }

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

            Users = new ObservableCollection<User>
            {
                new User {Name = "Гомодрил", UsrNmbr = "89834608775" }
            };
        }
        private ICommand addFriend;
        public ICommand AddFriend => addFriend ?? (addFriend = new RelayCommand(AddUser));
        public void AddUser()
        {
            User user = new User() { Name = NewName, UsrNmbr = NewUsrNmbr };
            Users.Insert(0, user);
            NewUser = user;
        }

        private ICommand addCommand;
        public ICommand AddCommand => addCommand ?? (addCommand = new RelayCommand(AddLog));
   
        public void AddLog()
        {
            Login login = new Login() { Log = LogName };
            Window1 window = new Window1();
            MainWindow main = new MainWindow();
            Logins.Insert(0, login);
            NewLog = login;
            window.Show();
        }



    }
}
