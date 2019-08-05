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

namespace PhoneApp1
{
    public partial class Appreciation : PhoneApplicationPage
    {
        public Appreciation()
        {
            InitializeComponent();
          
        }

      
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MiBand.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MiBook.xaml", UriKind.Relative));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MiPhone.xaml", UriKind.Relative));
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MiTV.xaml", UriKind.Relative));
        }

       


        
    }
}