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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Sales : Page
    {
        MainHeader headerClass;
        public Sales(MainHeader header)
        {
            headerClass = header;
            InitializeComponent();
            if (header.saleMade1)
            {
                a.Visibility = Visibility.Visible;
                b.Visibility = Visibility.Visible;
                c.Visibility = Visibility.Visible;
                d.Visibility = Visibility.Visible;
                Chart.Source = new BitmapImage(new Uri("Images/graph2.png", UriKind.Relative));
            }
           
        }
    }
}
