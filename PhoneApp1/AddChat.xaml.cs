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
using System.Windows.Media.Imaging;

namespace PhoneApp1
{
    public partial class AddChat : PhoneApplicationPage
    {
        Service1SoapClient sc = new Service1SoapClient();
        public int i;
        public AddChat()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            sc.GetAllChatCompleted += new EventHandler<GetAllChatCompletedEventArgs>(sc_GetAllChatCompleted);
            sc.GetAllChatAsync();
            App app = Application.Current as App;
            string deviceID = app.DivceID;
            this.image4.Source = new BitmapImage(new Uri("Images/"+deviceID+".jpg", UriKind.Relative));  
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            string deviceID = app.DivceID;
            string userID = app.ID;
            if (textBox1.Text != "")
            {
                try
                {

                    sc.InsertChatDetailsCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(sc_InsertChatDetailsCompleted);
                    sc.InsertChatDetailsAsync(i + 1, int.Parse(deviceID), int.Parse(userID), textBox1.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("Wrong");
                }

            }
            else
            {
                MessageBox.Show("Say something OK?");
            }
        }

        void sc_GetAllChatCompleted(object sender, GetAllChatCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            foreach (Chat s in e.Result)
            {
                i = s.ChatID;
            }
        }

        void sc_InsertChatDetailsCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            textBox1.Text = "";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Connect.xaml", UriKind.Relative));
        }
    }
}