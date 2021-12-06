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
        MainHeader headerClass;
        bool showNewCommission1=false;
        bool showNewCommission2 = false;



        public CommissionProgress(Window Parent,MainHeader header, bool commissionsAdded1, bool commissionsAdded2)
        {
            MainWindow = Parent;
            headerClass = header;
            showNewCommission1 = commissionsAdded1;
            showNewCommission2 = commissionsAdded2;
            InitializeComponent();

            if (commissionsAdded1)
            {

                commission1.Visibility = Visibility.Visible;
                
            }
        
            if (commissionsAdded2)
            {
                 commission2.Visibility = Visibility.Visible;
                    
                }
            if (header.saleMade1)
            {
                SalesTarget.SelectedIndex = 3;
            }
           
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
            
                if(SalesTarget.SelectedIndex == 3)
                {
                    headerClass.saleMade1 = true;
                }
                else
                {
                headerClass.saleMade2 = true;
            }

            

        }
       
        private void AddNewCommission_Click(object sender, RoutedEventArgs e)
        {
            if (headerClass.countCommissions == 0)
            {
                this.NavigationService.Navigate(new NewCommission(MainWindow, headerClass, "0000010"));
            }
            else if (headerClass.countCommissions == 1)
            {
                this.NavigationService.Navigate(new NewCommission(MainWindow, headerClass,"0000011"));
            }

            headerClass.countCommissions++;
        }
        private void CompleteForm_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Form(MainWindow, headerClass));
            //Page FormPage = new NewCommission2(MainWindow);
            //this.Content = FormPage;
        }
        private void CompleteForm_Click1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Form1(MainWindow, headerClass));
            //Page FormPage = new NewCommission2(MainWindow);
            //this.Content = FormPage;
        }
        private void CompleteForm_Click2(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Form2(MainWindow, headerClass));
            //Page FormPage = new NewCommission2(MainWindow);
            //this.Content = FormPage;
        }
        private void CompleteForm_Click3(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Form3(MainWindow, headerClass));
            //Page FormPage = new NewCommission2(MainWindow);
            //this.Content = FormPage;
        }

    }

}
