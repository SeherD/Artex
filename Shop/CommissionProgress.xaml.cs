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

namespace Shop
{
    /// <summary>
    /// Interaction logic for CommissionProgress.xaml
    /// </summary>
    public partial class CommissionProgress : Page
    {
        Window MainWindow;
        public CommissionProgress(Window Parent)
        {
            MainWindow = Parent;
            InitializeComponent();
        }

        private void CommissionSearch(object sender, TextChangedEventArgs e)
        {
            if (SearchBox.Text.Contains("9") || SearchBox.Text.Contains("W") || SearchBox.Text.Contains("T"))
            {
                grid1.Visibility = Visibility.Hidden;
                grid2.Visibility = Visibility.Visible;
                grid3.Visibility = Visibility.Hidden;
            }
            else if (SearchBox.Text.Contains("8") || SearchBox.Text.Contains("S") || SearchBox.Text.Contains("J"))
            {
                grid1.Visibility = Visibility.Hidden;
                grid2.Visibility = Visibility.Hidden;
                grid3.Visibility = Visibility.Visible;
            }
            else
            {
                grid1.Visibility = Visibility.Visible;
                grid2.Visibility = Visibility.Hidden;
                grid3.Visibility = Visibility.Hidden;
            }
        }

        private void CommissionStatusChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddNewCommission_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow.Navigate(new System.Uri("NewCommission.xaml",UriKind.RelativeOrAbsolute), MainWindow);
            this.NavigationService.Navigate(new NewCommission(MainWindow));
           
        }

        private void CompleteForm_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Form());
            //Page FormPage = new NewCommission2(MainWindow);
            //this.Content = FormPage;
        }

    }

}
