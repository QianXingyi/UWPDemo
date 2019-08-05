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

namespace PhoneApp1
{
    public partial class MiBand : PhoneApplicationPage
    {
        public MiBand()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            app.DivceID = "1001";
            NavigationService.Navigate(new Uri("/Chat.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            app.DivceID = "1001";
            NavigationService.Navigate(new Uri("/AddChat.xaml", UriKind.Relative));
        }
    }
}