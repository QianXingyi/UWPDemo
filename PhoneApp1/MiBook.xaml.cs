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
    public partial class MiBook : PhoneApplicationPage
    {
        public MiBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            app.DivceID = "1002";
            NavigationService.Navigate(new Uri("/Chat.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            app.DivceID = "1002";
            NavigationService.Navigate(new Uri("/AddChat.xaml", UriKind.Relative));
        }
    }
}