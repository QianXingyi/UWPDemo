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
    public partial class Chat1 : PhoneApplicationPage
    {
        Service1SoapClient sc = new Service1SoapClient();
       // public List<Chat> ChatList = new List<Chat>();
        public Chat1()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            string deviceID = app.DivceID;
            this.image4.Source = new BitmapImage(new Uri("Images/" + deviceID + ".jpg", UriKind.Relative));
            sc.FindChatByDIDCompleted += new EventHandler<FindChatByDIDCompletedEventArgs>(sc_FindChatByDIDCompleted);
            sc.FindChatByDIDAsync(deviceID);
        }

        void sc_FindChatByDIDCompleted(object sender, FindChatByDIDCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            foreach (Chat s in e.Result)
            {
                listBox1.Items.Add(s.Comment);
            }
            

        }
    }
}