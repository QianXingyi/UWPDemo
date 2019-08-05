using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Threading;
using PhoneApp1.ServiceReference1;

namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        Service1SoapClient sc = new Service1SoapClient();
        public User webUser = new User();
        public User loginUser = new User();
        public MainPage()
        {
            InitializeComponent();
           // sc.FindDeviceCompleted += new EventHandler<FindDeviceCompletedEventArgs>(sc_FindDeviceCompleted);
            sc.FindUIDCompleted += new EventHandler<FindUIDCompletedEventArgs>(sc_FindUIDCompleted);
        }

        

       // void sc_FindDeviceCompleted(object sender, FindDeviceCompletedEventArgs e)
       // {
       //     List<Device> devices = e.Result;

       // }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string ID = TextBoxID.Text;
            string Password = PasswordBox.Password;
            
            loginUser.UID = int.Parse(ID);
            loginUser.Password = Password;
            sc.FindUIDAsync(ID);
           // NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
            //sc.FindUIDCompleted += new EventHandler<FindUIDCompletedEventArgs>(sc_FindUIDCompleted);

            

        }

        void sc_FindUIDCompleted(object sender, FindUIDCompletedEventArgs e)
        {
            webUser = e.Result;
            if (webUser.Password == loginUser.Password)
            {
                App app = Application.Current as App;
                app.ID = loginUser.UID.ToString();
                NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
               // NavigationService.Navigate(new Uri("/Welcome.xaml", UriKind.Relative));

            }

            else
            {
                //NavigationService.Navigate(new Uri("/login.xaml", UriKind.Relative));
                waringBlock.Text = "ID or Pass have wrong!";

            }
            //return webUser;
        }

        private void TextBoxID_Tap(object sender, GestureEventArgs e)
        {
            TextBoxID.Text = "";
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewUser.xaml", UriKind.Relative));
        }
    }
}