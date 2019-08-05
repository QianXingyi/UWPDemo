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
using PhoneApp1.ServiceReference1;

namespace PhoneApp1
{
    public partial class Page1 : PhoneApplicationPage
    {
        Service1SoapClient sc = new Service1SoapClient();
        public Page1()
        {

            InitializeComponent();

        }

        void sc_FindUIDCompleted(object sender, FindUIDCompletedEventArgs e)
        {
            User webUser = new User();
            webUser = e.Result;
            idBlock.Text = webUser.UID.ToString();
            nameBlock.Text = webUser.Uname;
            ageBlock.Text = webUser.Uage.ToString();
            sexBlock.Text = webUser.Usex;
            dateBlock.Text = webUser.Udate;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            string ID = app.ID;
            
            sc.FindUIDCompleted += new EventHandler<FindUIDCompletedEventArgs>(sc_FindUIDCompleted);
            sc.FindUIDAsync(ID);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Appreciation.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyComments.xaml", UriKind.Relative));
        }
    }
}