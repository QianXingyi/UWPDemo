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
    public partial class MyComments : PhoneApplicationPage
    {
        Service1SoapClient sc = new Service1SoapClient();
        public MyComments()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            string ID = app.ID;
            sc.FindChatByUIDCompleted += new EventHandler<FindChatByUIDCompletedEventArgs>(sc_FindChatByUIDCompleted);
            sc.FindChatByUIDAsync(ID);
        }

        void sc_FindChatByUIDCompleted(object sender, FindChatByUIDCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            foreach (Chat s in e.Result)
            {
                listBox1.Items.Add(s.Comment);
            }
        }
    }
}