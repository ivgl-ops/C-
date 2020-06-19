using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace MyFavOperator
{
    public class PhoneViewModel
    {
        public ObservableCollection<PrimaryViewModel> Logs { get; set; } = new ObservableCollection<PrimaryViewModel>();
        public IKITMobile IKITMobile = new IKITMobile();
        public string MobileUser { get; set; }
        public ContactModel SelectedContact { get; set; }

        private RelayCommand _addClient;
        public RelayCommand AddClient
        {
            get
            {
                return _addClient ?? (_addClient = new RelayCommand(register));
            }
        }
        public void register()
        {
            PrimaryViewModel primary = new PrimaryViewModel(IKITMobile) { NewClient = MobileUser };
            PrimaryWin win = new PrimaryWin(primary);
            PasswordView password = new PasswordView();
            password.Show();
            password.Close();
            win.Show();
        }
        
    }
}
