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
    /// Interaction logic for EditShopPage.xaml
    /// </summary>
    public partial class EditShopPage : Page
    {
        public EditShopPage()
        {
            InitializeComponent();
            leftcount = ImageHolder.Children.Count-1;
            for (int i = 1; i < ImageHolder.Children.Count; i++)
            {
                if (ImageHolder.Children[i].GetType().Name == "StackPanel")
                {
                    StackPanel image = (StackPanel)ImageHolder.Children[i];
                    image.Visibility = Visibility.Collapsed;
                }

                
            }
        }
        bool sort = false;

        int rightcount=0;
        void RightMove(object sender, RoutedEventArgs e)
        { rightcount++;

            if(rightcount== ImageHolder.Children.Count)
            {
                rightcount = 0;
            }

            if (!sort) {
                for (int i = 0; i < ImageHolder.Children.Count; i++)
                {
                    if (i == rightcount)
                    {
                        if (ImageHolder.Children[i].GetType().Name == "StackPanel")
                        {
                            StackPanel image = (StackPanel)ImageHolder.Children[i];
                            image.Visibility = Visibility.Visible;
                        }
                    }

                    else
                    {
                        if (ImageHolder.Children[i].GetType().Name == "StackPanel")
                        {
                            StackPanel image = (StackPanel)ImageHolder.Children[i];
                            image.Visibility = Visibility.Collapsed;
                        }

                    }
                }
            }
            else
            {
                for (int i = 0; i < SortedPrice.Children.Count; i++)
                {
                    if (i == rightcount)
                    {
                        if (SortedPrice.Children[i].GetType().Name == "StackPanel")
                        {
                            StackPanel image = (StackPanel)SortedPrice.Children[i];
                            image.Visibility = Visibility.Visible;
                        }
                    }

                    else
                    {
                        if (SortedPrice.Children[i].GetType().Name == "StackPanel")
                        {
                            StackPanel image = (StackPanel)SortedPrice.Children[i];
                            image.Visibility = Visibility.Collapsed;
                        }

                    }
                }
            }
        }
        int leftcount;
        void LeftMove(object sender, RoutedEventArgs e)
        {
            leftcount--;
            if (leftcount == -1)
            {
                leftcount = ImageHolder.Children.Count-1;
            }

            if (!sort)
            {
                for (int i = 0; i < ImageHolder.Children.Count; i++)
                {
                    if (i == leftcount)
                    {
                        if (ImageHolder.Children[i].GetType().Name == "StackPanel")
                        {
                            StackPanel image = (StackPanel)ImageHolder.Children[i];
                            image.Visibility = Visibility.Visible;
                        }
                    }

                    else
                    {
                        if (ImageHolder.Children[i].GetType().Name == "StackPanel")
                        {
                            StackPanel image = (StackPanel)ImageHolder.Children[i];
                            image.Visibility = Visibility.Collapsed;
                        }

                    }
                }

            }
            else
            {
                for (int i = 0; i < SortedPrice.Children.Count; i++)
                {
                    if (i == leftcount)
                    {
                        if (SortedPrice.Children[i].GetType().Name == "StackPanel")
                        {
                            StackPanel image = (StackPanel)SortedPrice.Children[i];
                            image.Visibility = Visibility.Visible;
                        }
                    }

                    else
                    {
                        if (SortedPrice.Children[i].GetType().Name == "StackPanel")
                        {
                            StackPanel image = (StackPanel)SortedPrice.Children[i];
                            image.Visibility = Visibility.Collapsed;
                        }

                    }
                }
            }
            
        }


        void search(object sender, TextChangedEventArgs args)
        {
            if (SearchBox.Text.Contains("Five Star"))
            {
                RightButton.IsEnabled = false;
                LeftButton.IsEnabled = false;
                for (int i = 1; i < ImageHolder.Children.Count; i++)
                {
                    if (ImageHolder.Children[i].GetType().Name == "StackPanel")
                    {
                        StackPanel image = (StackPanel)ImageHolder.Children[i];
                        image.Visibility = Visibility.Collapsed;
                    }


                }
            }

            else if (SearchBox.Text.Contains("Color"))
            {
                RightButton.IsEnabled = false;
                LeftButton.IsEnabled = false;
                for (int i = 0; i < ImageHolder.Children.Count; i++)
                {
                    if (i == 4)
                    {
                        if (ImageHolder.Children[i].GetType().Name == "StackPanel")
                        {
                            StackPanel image = (StackPanel)ImageHolder.Children[i];
                            image.Visibility = Visibility.Visible;
                        }
                    }

                    else
                    {
                        if (ImageHolder.Children[i].GetType().Name == "StackPanel")
                        {
                            StackPanel image = (StackPanel)ImageHolder.Children[i];
                            image.Visibility = Visibility.Collapsed;
                        }

                    }
                }

            }
            else
            {
                RightButton.IsEnabled = true;
                LeftButton.IsEnabled = true;

            }

        }


        void tag1(object sender, RoutedEventArgs e)
        {
            RightButton.IsEnabled = false;
            LeftButton.IsEnabled = false;
            for (int i = 1; i < ImageHolder.Children.Count; i++)
            {
                if (ImageHolder.Children[i].GetType().Name == "StackPanel")
                {
                    StackPanel image = (StackPanel)ImageHolder.Children[i];
                    image.Visibility = Visibility.Collapsed;
                }


            }
        }

        void tag2(object sender, RoutedEventArgs e)
        {
            RightButton.IsEnabled = false;
            LeftButton.IsEnabled = false;
            for (int i = 0; i < ImageHolder.Children.Count; i++)
            {
                if (i == 2)
                {
                    if (ImageHolder.Children[i].GetType().Name == "StackPanel")
                    {
                        StackPanel image = (StackPanel)ImageHolder.Children[i];
                        image.Visibility = Visibility.Visible;
                    }
                }

                else
                {
                    if (ImageHolder.Children[i].GetType().Name == "StackPanel")
                    {
                        StackPanel image = (StackPanel)ImageHolder.Children[i];
                        image.Visibility = Visibility.Collapsed;
                    }

                }
            }
        }

        void uncheck(object sender, RoutedEventArgs e) {
            RightButton.IsEnabled = true;
            LeftButton.IsEnabled = true;
        }

        void sortedPrice(object sender, RoutedEventArgs e)
        {
            ImageHolder.Visibility = Visibility.Collapsed;
            SortedPrice.Visibility = Visibility.Visible;
            sort = true;

        }

        void unsortedPrice(object sender, RoutedEventArgs e)
        {
            ImageHolder.Visibility = Visibility.Visible;
            SortedPrice.Visibility = Visibility.Collapsed;
            sort = false;

        }
    }
}
