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
    /// AboutWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AboutWindow : Window
    {
        Service1SoapClient sc = new Service1SoapClient();

        public AboutWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            string deviceID = app.DivceID;
            this.image1.Source = new BitmapImage(new Uri("Images/" + deviceID + ".jpg", UriKind.Relative));
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            commentlistBox.Items.Clear();
            App app = Application.Current as App;
            string deviceID = app.DivceID;
            
            foreach (Chat s in sc.FindChatByDID(deviceID))
            {
                
                commentlistBox.Items.Add(s.Comment);
            }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            string deviceID = app.DivceID;
            string ID=app.ID;
            int i=0;
            foreach (Chat s in sc.GetAllChat())
            {
                i = s.ChatID;
            }
            Chat addChat = new Chat();
            if (sayBox.Text!="")
            {
                addChat.ChatID = (i + 1);
                addChat.DID=int.Parse(deviceID);
                addChat.UID = int.Parse(ID);
                addChat.Comment = sayBox.Text;
                sc.InsertChatDetails(addChat.ChatID, addChat.DID, addChat.UID, addChat.Comment);
                MessageBox.Show("Thank you for your comment!");
                sayBox.Text = "";
            }
            else
            {
                MessageBox.Show("You must say something!");
            }
           
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow win = new HomeWindow();
            this.Close();
            win.Show();
        }
    }
}
