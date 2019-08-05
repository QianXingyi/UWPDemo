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
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        Service1SoapClient sc = new Service1SoapClient();
        public Login()
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            string ID = app.ID;
           

            User webUser = new User();
            webUser = sc.FindUID(ID);
            idlabel.Content = webUser.UID.ToString();
            namelabel.Content = webUser.Uname;
            agelabel.Content = webUser.Uage.ToString();
            sexlabel.Content = webUser.Usex;
            datelabel.Content = webUser.Udate;


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow win = new HomeWindow();
            this.Close();
            win.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            this.Close();
            win.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            string ID = app.ID;
            //sc.FindChatByUID(ID);
            foreach (Chat s in sc.FindChatByUID(ID))
            {
                listBox1.Items.Add(s.Comment);
            }
            listBox1.Visibility = Visibility.Visible;

        }
    }
}
