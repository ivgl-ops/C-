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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackListt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrimaryView primary = new PrimaryView { DataContext = new MainWindowViewModel(password.Password, login.Text) };
                primary.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Не правильно введен логин или пароль");
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            popup1.IsOpen = true;
        }
    }
}
