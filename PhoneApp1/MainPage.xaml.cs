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
    

    public partial class adv : PhoneApplicationPage
    {
        DispatcherTimer timer;

        public adv()
        {
            InitializeComponent();
            {
                timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 5);
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new Uri("/login.xaml", UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new Uri("/login.xaml", UriKind.Relative));
        }
    }
}