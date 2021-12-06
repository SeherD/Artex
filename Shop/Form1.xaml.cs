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
    /// Interaction logic for Form.xaml
    /// </summary>
    
    public partial class Form1 : Page
    {
        Window MainWindow;
        MainHeader headerClass;
        public Form1(Window Parent, MainHeader header)
        {
            MainWindow = Parent;
            headerClass = header;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CommissionProgress(MainWindow, headerClass, false, false));
        }
    }
}
