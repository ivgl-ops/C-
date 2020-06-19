using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace MyFavOperator
{
    public class PasswordViewModel
    {
        public int One { get; set; }
        public int Two { get; set; }
        public int Three { get; set; }
        public int Four { get; set; }
        public PasswordViewModel()
        {
            Random random = new Random();
            One = random.Next(0, 10);
            Two = random.Next(0, 10);
            Three = random.Next(0, 10);
            Four = random.Next(0, 10);
        }
        private RelayCommand _winclose;
        public RelayCommand WinClose
        {
            get
            {
                return _winclose ?? (_winclose = new RelayCommand(WinClosed));
            }
        }
        private void WinClosed()
        {
            PasswordView password = new PasswordView();
            
        }
    }

}
