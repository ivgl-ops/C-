using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyFavOperator
{
    /// <summary>
    /// Логика взаимодействия для PrimaryWin.xaml
    /// </summary>
    public partial class PrimaryWin : Window
    {
        public PrimaryWin(PrimaryViewModel primary)
        {
            InitializeComponent();
            DataContext = primary;
            primary.AnswerCall += _phoneAnswerCall;
        }
        public void _phoneAnswerCall(string dialedNumber)
        {
            Label.Content = "Вам звонит - " + dialedNumber;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
