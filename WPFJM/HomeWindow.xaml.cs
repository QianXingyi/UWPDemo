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
using System.Windows.Shapes;
using WPFJM.ServiceReference1;

namespace WPFJM
{
    /// <summary>
    /// HomeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HomeWindow : Window
    {
        Service1SoapClient sc = new Service1SoapClient();
        public HomeWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            string ID = app.ID;
            User webUser = new User();
            webUser= sc.FindUID(ID);
            welcomelabel.Content = "Welcome:" + webUser.Uname + "!";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure to exit?");
            MainWindow win = new MainWindow();
            this.Close();
            win.Show();
        }

        private void bandbutton_Click(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            app.DivceID = "1001";
            AboutWindow win = new AboutWindow();
            this.Close();
            win.Show();
        }

        private void bookbutton_Click(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            app.DivceID = "1002";
            AboutWindow win = new AboutWindow();
            this.Close();
            win.Show();
        }

        private void phonebutton_Click(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            app.DivceID = "1003";
            AboutWindow win = new AboutWindow();
            this.Close();
            win.Show();
        }

        private void tvbutton_Click(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            app.DivceID = "1004";
            AboutWindow win = new AboutWindow();
            this.Close();
            win.Show();
        }
    }
}
