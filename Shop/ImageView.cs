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
using System.Linq;
using System.Collections;

namespace Shop
{
    /// <summary>
    /// Interaction logic for EmptyPage.xaml
    /// </summary>
    public partial class ImageView : Page
    {
        public ImageView()
        {
            InitializeComponent();
            DataContext = this;
            
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
        static System.Collections.IList _data= DefaultFolder._data;
        static ItemsControl _targetSource= DefaultFolder._targetSource;
      

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
            System.Collections.IList newList ;
            newList=DragTarget.Items;
           for (int i=newList.Count -1; i>=0;i-- )
            {
                var data = newList[i];
                DragTarget.Items.RemoveAt(i);
                _targetSource.Items.Add(data);
                
            }

            DragBox.Visibility = Visibility.Collapsed;
            FolderScroller.Visibility = Visibility.Visible;


        }
        private void AddNewFolder(object sender, RoutedEventArgs e)
        {
            string folderName="New Folder";
            var dialog = new AddFolder();
            if (dialog.ShowDialog() == true)
            {
                folderName= dialog.ResponseText;
            }
            else
            {
                return;
            }
            Button folder = new Button { Background = Brushes.White ,
                Height = 70,
                Width = 70,
                AllowDrop = true,
              
                Margin = new Thickness(5, 5, 5, 5)


        };
            StackPanel internalPanel = new StackPanel();
            Image folderImage = new Image
            {
                Source = new BitmapImage(new Uri("Images/folder.png", UriKind.Relative)),
                Height = 30,
            };

            internalPanel.Children.Add(folderImage);
            internalPanel.Children.Add(new TextBlock { Text=folderName });
            folder.Drop += new DragEventHandler(image_Drop);
            folder.Click += new RoutedEventHandler(FolderView);
            folder.Content = internalPanel;
            FolderHolder.Children.Add(folder);
           

        }
        List<ListBoxItem> checkItems = new List<ListBoxItem>();

        private void checkboxIsChecked(object sender, RoutedEventArgs e)
        {  foreach(var check in CheckboxHolder.Children)
            {
                if (check.GetType().Name == "CheckBox")
                {
                    CheckBox checkbox = (CheckBox)check;
                   if((bool)checkbox.IsChecked)
                    {//checkbox.Content.ToString()
                        foreach (var child in ImageFolder.Items)
                        {
                            if (child.GetType().Name == "ListBoxItem")
                            {
                                ListBoxItem list = (ListBoxItem)child;
                                if (list.Content.GetType().Name == "StackPanel")
                                {
                                    StackPanel holder = (StackPanel)list.Content;
                                    foreach (var text in holder.Children)
                                    {

                                        if (text.GetType().Name == "TextBlock")
                                        {
                                            TextBlock textHolder = (TextBlock)text;
                                            if (textHolder.Text.Contains("Tags: #" + checkbox.Content.ToString().ToLower()))
                                            {
                                                checkItems.Add(list);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (var x in ImageFolder.Items)
            {
                if (x.GetType().Name == "ListBoxItem")
                {
                    ListBoxItem list = (ListBoxItem)x;
                    if (!checkItems.Contains(list))
                    {
                        list.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        list.Visibility = Visibility.Visible;
                    }
                }
            }




        }


        private void checkboxIsUnchecked(object sender, RoutedEventArgs e)
        { bool flag = false;
            foreach (var check in CheckboxHolder.Children)
            {
                if (check.GetType().Name == "CheckBox")
                {
                    CheckBox checkbox = (CheckBox)check;
                    if ((bool)checkbox.IsChecked) {
                        flag = true;
                    }

                }

            }
            if (!flag)
            {
                foreach (var child in ImageFolder.Items)
                {
                    if (child.GetType().Name == "ListBoxItem")
                    {

                        ListBoxItem list = (ListBoxItem)child;
                        list.Visibility = Visibility.Visible;
                    }
                }

                checkItems.Clear();

                return;
            }


             foreach (var check in CheckboxHolder.Children)
            {
                if (check.GetType().Name == "CheckBox")
                {
                    CheckBox checkbox = (CheckBox)check;
                   if(!(bool)checkbox.IsChecked)
                    {//checkbox.Content.ToString()
                        foreach (var child in ImageFolder.Items)
                        {
                            if (child.GetType().Name == "ListBoxItem")
                            {
                                ListBoxItem list = (ListBoxItem)child;
                                if (list.Content.GetType().Name == "StackPanel")
                                {
                                    StackPanel holder = (StackPanel)list.Content;
                                    foreach (var text in holder.Children)
                                    {

                                        if (text.GetType().Name == "TextBlock")
                                        {
                                            TextBlock textHolder = (TextBlock)text;
                                            if (textHolder.Text.Contains("Tags: #" + checkbox.Content.ToString().ToLower()))
                                            { if (checkItems.Contains(list))
                                                checkItems.Remove(list);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


            foreach (var x in ImageFolder.Items)
            {
                if (x.GetType().Name == "ListBoxItem")
                {
                    ListBoxItem list = (ListBoxItem)x;
                    if (!checkItems.Contains(list))
                    {
                        list.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        list.Visibility = Visibility.Visible;
                    }
                }
            }

        }


        private void search(object sender, TextChangedEventArgs args)
        {
            foreach (var x in ImageFolder.Items)
            {
                if (x.GetType().Name == "ListBoxItem")
                {
                    ListBoxItem list = (ListBoxItem)x;
                    list.Visibility = Visibility.Collapsed;

                }
            }
            foreach (var child in ImageFolder.Items)
            {
                if (child.GetType().Name == "ListBoxItem")
                {
                    ListBoxItem list = (ListBoxItem)child;
                    if (list.Content.GetType().Name == "StackPanel")
                    {
                        StackPanel holder = (StackPanel)list.Content;
                        foreach (var text in holder.Children)
                        {

                            if (text.GetType().Name == "TextBlock")
                            {
                                TextBlock textHolder = (TextBlock)text;
                                if (textHolder.Text.Contains("Title: "+SearchBox.Text))
                                {
                                    list.Visibility = Visibility.Visible;
                                }

                                else
                                {
                                    //list.Visibility = Visibility.Collapsed;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void FolderView(object sender, RoutedEventArgs e)
        {
            if(sender.GetType().Name == "Button")
            {
                Button folder = (Button)sender;
                StackPanel folderContent = (StackPanel)folder.Content;
                foreach(var child in folderContent.Children)
                {
                    if (child.GetType().Name == "TextBlock")
                    {
                        TextBlock text = (TextBlock)child;
                        FolderName.Text = text.Text;
                        if (text.Text == "Default")
                        {
                            Default.Visibility = Visibility.Visible;
                            OilPainting.Visibility = Visibility.Hidden;
                            Watercolors.Visibility = Visibility.Hidden;

                            ListBox content = (ListBox)Default.Content;
                            foreach (var x in content.Items)
                            {
                                if (x.GetType().Name == "ListBoxItem")
                                {
                                    ListBoxItem y = (ListBoxItem)x;
                                    y.Visibility = Visibility.Visible;

                                }
                            }

                        }
                        else if (text.Text == "Oil Paintings")
                        {
                            Default.Visibility = Visibility.Hidden;
                            OilPainting.Visibility = Visibility.Visible;
                            Watercolors.Visibility = Visibility.Hidden;
                        }
                        else if (text.Text == "Watercolors") {
                            Default.Visibility = Visibility.Hidden;
                            OilPainting.Visibility = Visibility.Hidden;
                            Watercolors.Visibility = Visibility.Visible;
                        }
                        else
                        { ListBox content = (ListBox)Default.Content;
                            foreach (var x in content.Items)
                            {
                               if( x.GetType().Name == "ListBoxItem"){
                                    ListBoxItem y = (ListBoxItem)x;
                                    y.Visibility = Visibility.Collapsed;

                                }
                            }
                        }
                    }
                        
                }

               
            }
        }


        private void AddShop_Click(object sender, RoutedEventArgs e)
        {
            DragBox.Visibility = Visibility.Visible;
            FolderScroller.Visibility = Visibility.Collapsed;

        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            DragBox.Visibility = Visibility.Collapsed;
            FolderScroller.Visibility = Visibility.Visible;
            DragTarget.Items.Clear();

        }



    }
  }

