using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace MyFavOperator
{
    public class PrimaryViewModel
    {        
        public string NewName { get; set; }
        public string NewNumber { get; set; }
        public string NewClient { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();
        public ContactModel SelectedContact { get; set; }
        public ContactModel SelectedContact1 { get; set; }
        public delegate void AnswerCallHandler(string dialedNumber);

        public event AnswerCallHandler AnswerCall;
        public event CallHandler Call;

        public PrimaryViewModel(IKITMobile mobile)
        {
            Contacts = new ObservableCollection<ContactModel>
            {

            };
            mobile.AddPhone(this);
        }
        private RelayCommand _addContact;
        public RelayCommand AddContact
        {
            get
            {
                return _addContact ?? (_addContact = new RelayCommand(createClient));
            }
        }
        public void createClient()
        {
            ContactModel contact = new ContactModel() { Name = NewName, Number = NewNumber };
            Contacts.Insert(0, contact);

        }
        private RelayCommand _dialingNumberCommand;
        public RelayCommand DialingNumberCommand
        {
            get
            {
                return _dialingNumberCommand ?? (_dialingNumberCommand = new RelayCommand(DialingNumber));
            }
        }

        public void DialingNumber()
        {
            Call(NewClient, SelectedContact.Number);
        }
        public void ReceiveCall(string callingNumber, string dialedNumber)
        {
            var numbers = Contacts.Where(phone => phone.Number == callingNumber).ToList();

            if (NewClient == dialedNumber)
            {
                if (numbers.Any())
                {
                    AnswerCall(callingNumber);
                }
                else
                {
                    AnswerCall("Не известный номер");
                }
            }
            
        }

    } 
}

