using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Artex
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        private void Login(object sender, RoutedEventArgs e)
        {
            Storyboard sb = Resources["btn_login_Click"] as Storyboard;
            
        }

        private void SignUp(object sender, RoutedEventArgs e)
        {
            Storyboard sb = Resources["btn_signUp_Click"] as Storyboard;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new System.Uri("LoginWindow.xaml", UriKind.Relative));
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new System.Uri("SignUpWindow.xaml", UriKind.Relative));
        }
    }
    
}
