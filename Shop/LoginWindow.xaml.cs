using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Artex
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Page
    {
       
        public LoginWindow()
        {
            
            InitializeComponent();
        }

        private void txt_userName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void txt_password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (this.txt_userName.Text.ToString() == "123"&& this.txt_password.Text.ToString()=="123")
            {
                MessageBox.Show("Login successful!!");
                Window MainApplication = new Shop.MainHeader();
                MainApplication.Show();
                Window ThisWindow = Window.GetWindow(this);
                ThisWindow.Close();
                
               // NavigationService.GetNavigationService(this).Navigate(new System.Uri("Page1.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Login failed, username or password are wrong!!");
            }
            
            


        }
    }
}
