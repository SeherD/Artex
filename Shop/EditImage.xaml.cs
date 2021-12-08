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
using System.Windows.Shapes;

namespace Shop
{
    /// <summary>
    /// Interaction logic for EditImage.xaml
    /// </summary>
    public partial class EditImage : Window
    {
        public string newTitle;
        public string newTag;
        public string addedTag;
        public EditImage(string title, string uri,string tag)
        {
            InitializeComponent();
            NewTitle.Text = title;
            SenderImage.Source = new BitmapImage(new Uri(uri, UriKind.Relative));
        }

        private void NewTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            newTag = (string)EditTag.SelectedItem;
        }

        private void NewTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            newTitle = NewTitle.Text;
        }

        private void NewTag_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = false;

        }

        private void Text_Click(object sender, RoutedEventArgs e)
        {
            EditTag.Items.Add(NewTag.Text);
            addedTag = NewTag.Text;
        }
    }
}
