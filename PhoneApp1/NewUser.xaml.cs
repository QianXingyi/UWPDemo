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
    public partial class NewUser : PhoneApplicationPage
    {
       public User addUser = new User();
        Service1SoapClient sc = new Service1SoapClient();
        public int i;
        public NewUser()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            sc.GetAllUserCompleted += new EventHandler<GetAllUserCompletedEventArgs>(sc_GetAllUserCompleted);
            sc.GetAllUserAsync();
        }

        void sc_GetAllUserCompleted(object sender, GetAllUserCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            foreach (User s in e.Result)
            {
                i = s.UID;
            }
            addUser.UID = i+1;
            idBlock.Text = (i + 1).ToString();
        }

        private void maleRadio_Checked(object sender, RoutedEventArgs e)
        {
            femaleRadio.IsChecked = false;
            addUser.Usex="M";
        }

        private void femaleRadio_Checked(object sender, RoutedEventArgs e)
        {
            maleRadio.IsChecked = false;
            addUser.Usex = "F";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if ((passwordBox.Password == surePassword.Password) && (passwordBox.Password != ""))
            {
                
                //addUser.UID = int.Parse(idtextBox.Text);
                addUser.Uname = nametextBox.Text;
                addUser.Uage = int.Parse(agetextBox.Text);
                addUser.Udate = datatextBox.Text;
                addUser.Password = passwordBox.Password;
                App app = Application.Current as App;
                app.ID = addUser.UID.ToString();
                sc.InsertUserDetailsCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(sc_InsertUserDetailsCompleted);
                sc.InsertUserDetailsAsync(addUser.UID, addUser.Uname, addUser.Uage, addUser.Usex, addUser.Udate, addUser.Password);
                NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
            }
            else 
            {
                waringtextBlock.Text = "Make Sure!";
            }
        }

        void sc_InsertUserDetailsCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}