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
    /// Interaction logic for ArtistSignupWindow.xaml
    /// </summary>
    public partial class ArtistSignupWindow : Page
    {
        public ArtistSignupWindow()
        {
            InitializeComponent();
        }
        private void txt_userName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void txt_password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void txt_confirmPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (this.txt_userName.Text.ToString() == "123")
            {
                MessageBox.Show("Failed! Username already exist!!!");
            }
            else if (this.txt_password.Text.ToString() != this.txt_confirmPassword.Text.ToString())
            {
                MessageBox.Show("Failed! Passwords do not match!!! Try again");
            }
            else
            {
                MessageBox.Show("Sign Up successful!!! Login using your credentials");
                NavigationService.GetNavigationService(this).Navigate(new System.Uri("Page1.xaml", UriKind.Relative));
            }

        }
    }
}
