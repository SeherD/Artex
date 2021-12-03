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
    /// Interaction logic for DefaultFolder.xaml
    /// </summary>
    public partial class DefaultFolder : Page
    {
        public DefaultFolder()
        {
            InitializeComponent();
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
       public static System.Collections.IList _data;
        public static ItemsControl _targetSource;

    }
}
