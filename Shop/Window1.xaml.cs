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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void NotAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = false ;
        }
        private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = false;
        }



        #region Drag Drop Support

        Point startPoint;

        void List_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        void List_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            Image image = e.Source as Image;
            if (e.LeftButton == MouseButtonState.Pressed
                && (
                    Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance
                    || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {

                // Get the dragged ListViewItem
                // var items = string.Join(", ", List.SelectedItems.Cast<string>().ToArray());
                ListBox listBox = sender as ListBox;
                /* Hold a reference to the source*/
                _targetSource = listBox;


                _data = listBox.SelectedItems;

                DragDrop.DoDragDrop(listBox, _data, DragDropEffects.Copy);
                // Initialize the drag & drop operation
                // DataObject dragData = new DataObject(DataFormats.UnicodeText, items);
                // DragDrop.DoDragDrop(List, dragData, DragDropEffects.Copy);
            }
        }

        #endregion
        static System.Collections.IList _data = DefaultFolder._data;
        static ItemsControl _targetSource = DefaultFolder._targetSource;


        private void image_Drop(object sender, DragEventArgs e)
        {
            List<ListBoxItem> selected = new List<ListBoxItem>();

            foreach (ListBoxItem data in _targetSource.Items)
            {
                if (data.IsSelected == true)
                {
                    selected.Add(data);
                }
            }
            //control.Items.Add(e.Data);
            foreach (var data in selected)
            {
                /*if (data is UIElement element)
                {
                    element.Visibility = Visibility.Hidden;
                }*/
                _targetSource.Items.Remove(data);
            }
        }

        private void shop_Drop(object sender, DragEventArgs e)
        {
            List<ListBoxItem> selected = new List<ListBoxItem>();

            foreach (ListBoxItem data in _targetSource.Items)
            {
                if (data.IsSelected == true)
                {
                    selected.Add(data);
                }
            }
            //control.Items.Add(e.Data);
            foreach (var data in selected)
            {
                /*if (data is UIElement element)
                {
                    element.Visibility = Visibility.Hidden;
                }*/
                _targetSource.Items.Remove(data);
                DragTarget.Items.Add(data);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            List<ListBoxItem> selected = new List<ListBoxItem>();
            System.Collections.IList newList;
            newList = DragTarget.Items;
            for (int i = newList.Count - 1; i >= 0; i--)
            {
                var data = newList[i];
                DragTarget.Items.RemoveAt(i);
                _targetSource.Items.Add(data);

            }

            DragBox.Visibility = Visibility.Collapsed;
        


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            DragBox.Visibility = Visibility.Collapsed;
            

        }
    }
}
