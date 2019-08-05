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
    /// NewUser.xaml 的交互逻辑
    /// </summary>
    public partial class NewUser : Window
    {
        public User addUser = new User();
        Service1SoapClient sc = new Service1SoapClient();
        int i;
        public NewUser()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            foreach (User s in sc.GetAllUser())
            {
                i = s.UID;
            }
            addUser.UID = i + 1;
            idlabel.Content= (i + 1).ToString();
        }

        private void maleradioButton_Checked(object sender, RoutedEventArgs e)
        {
            femaleradioButton.IsChecked = false;
            addUser.Usex = "M";
        }

        private void femaleradioButton_Checked(object sender, RoutedEventArgs e)
        {
            maleradioButton.IsChecked = false;
            addUser.Usex = "F";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if ((passwordBox1.Password == passwordBox2.Password) && (passwordBox1.Password != ""))
            {
                addUser.Uname = nametextBox.Text;
                addUser.Uage = int.Parse(agetextBox.Text);
                addUser.Udate = datetextBox.Text;
                addUser.Password = passwordBox1.Password;
                App app = Application.Current as App;
                app.ID = addUser.UID.ToString();
                sc.InsertUserDetails(addUser.UID, addUser.Uname, addUser.Uage, addUser.Usex, addUser.Udate, addUser.Password);
                HomeWindow win = new HomeWindow();
                this.Close();
                win.Show();
            }
            else
            {
                makeSurelabel.Content = "Make Sure!";
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            this.Close();
            win.Show();
        }
    }
}
