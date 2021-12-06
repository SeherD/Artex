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
    /// Interaction logic for NewCommission.xaml
    /// </summary>
    public partial class NewCommission : Page
    {
        Window MainWindow;
        MainHeader headerClass;
        string custId;
        public NewCommission(Window Parent, MainHeader header,  string id)
        {
            MainWindow = Parent;
            headerClass = header;
            custId = id;
            
            InitializeComponent();
            CustomerId.Text = "ID:"+custId;
        }

        private void SubmitButtonClick(object sender, RoutedEventArgs e)
        {   if(CustomerName.Text.Equals("James Carr"))
            {
                this.NavigationService.Navigate(new CommissionProgress(MainWindow,headerClass, true, false));
            }
               else if (CustomerName.Text.Equals("Taylor Smith"))
            {
                this.NavigationService.Navigate(new CommissionProgress(MainWindow,headerClass, true, true));
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Form(MainWindow, headerClass));
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
