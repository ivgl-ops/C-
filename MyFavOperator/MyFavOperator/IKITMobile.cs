using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavOperator
{
    public delegate void CallHandler(string callingNumber, string dialedNumber);

    public class IKITMobile
    {
        public List<PrimaryViewModel> Phones { get; } = new List<PrimaryViewModel>();
        public List<PrimaryViewModel> Names { get; } = new List<PrimaryViewModel>();
        public void AddPhone(PrimaryViewModel phone)
        {
            Phones.Insert(0, phone);
            phone.Call += DialingNumber;
            Call += phone.ReceiveCall;
        }
        public event CallHandler Call;
        public event CallHandler CallName;
        public void DialingNumber(string callingNumber, string dialedNumber)
        {
            Call(callingNumber, dialedNumber);
        }

    }
}
