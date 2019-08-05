using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFJM.ServiceReference1;

namespace WPFJM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Service1SoapClient sc = new Service1SoapClient();
        public User webUser = new User();
        public User loginUser = new User();
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void bandbutton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please login first!");
        }

        private void bookbutton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please login first!");
        }

        private void phonebutton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please login first!");
        }

        private void tvbutton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please login first!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void enterbutton_Click(object sender, RoutedEventArgs e)
        {
            string ID = idtextBox.Text;
            string Password =passwordBox.Password;

            loginUser.UID = int.Parse(ID);
            loginUser.Password = Password;
            webUser = sc.FindUID(ID);
            if (webUser.Password == loginUser.Password)
            {
                App app = Application.Current as App;
                app.ID = loginUser.UID.ToString();
                Login win = new Login();
                this.Close();
                win.Show();
            }
            else
            {
                MessageBox.Show("ID or Pass have wrong!");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NewUser win = new NewUser();
            this.Close();
            win.Show();
        }

    }
}
