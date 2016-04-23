using PhotoCore1._1.StaticFunctionClasses;
using PhotoCore1._1.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PhotoCore1._1.View
{
    /// <summary>
    /// Interaction logic for Library.xaml
    /// </summary>
    public partial class Library
    {
        public Library()
        {
            InitializeComponent();
        }
        public void SetContent(List<Bitmap> content)
        {
            LibraryViewModel.librarycontentBitmap = content;
            LibraryViewModel.librarycontent = ImageConverterFormat.BitmapListToBitmapImageList(content);
            SetAllImage(LibraryViewModel.librarycontent);
        }

        public List<System.Windows.Controls.Button> Images = new List<System.Windows.Controls.Button>();
        /// <summary>
        /// Set image to library
        /// </summary>
        /// <param name="ShowingBitmapImage"></param>
        public void SetAllImage(List<BitmapImage> ShowingBitmapImage)
        {
                for (int i = 0; i < ShowingBitmapImage.Count; i++)
                {
                    Images.Add(new System.Windows.Controls.Button());
                    Images[i].Name = "i" + i;
                    Images[i].Click += OpenOneImage;
                    float wi;
                    if (ShowingBitmapImage[i].Height < ShowingBitmapImage[i].Width)
                    {
                        wi = (float)(ShowingBitmapImage[i].Height / ShowingBitmapImage[i].Width);
                        Images[i].Height = 300 * wi;
                        Images[i].Width = 296;
                    }
                    else
                    {
                        wi = (float)(ShowingBitmapImage[i].Width / ShowingBitmapImage[i].Height);
                        Images[i].Height = 296;
                        Images[i].Width = 300 * wi;
                    }
                    Images[i].Margin = new Thickness(10, 10, 10, 10);
                    Images[i].Background = (this.DataContext as BaseViewModel).ColorsViewModel.ThemeColor;
                    Images[i].Content = new System.Windows.Controls.Image
                      {
                          Source = ShowingBitmapImage[i]
                      };
                    Second.Children.Add(Images[i]);
                }
        }
        /// <summary>
        /// Show selected image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OpenOneImage(object sender, EventArgs e)
        {
            System.Windows.Controls.Button a = sender as System.Windows.Controls.Button;
            string name = a.Name.ToString();
            name=name.Remove(0, 1);
            try
            {
                (this.DataContext as BaseViewModel).LibraryViewModel.SelectedIndex = int.Parse(name);
            }
            catch { }
            Second.Visibility = Visibility.Hidden;
            First.Visibility = Visibility.Visible;
        }

        private void Close_This(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            Second.Visibility = Visibility.Visible;
            First.Visibility = Visibility.Hidden;
        }

        private void KeyCombinations(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Right)
            {
                (this.DataContext as BaseViewModel).LibraryViewModel.NextC(sender);
            }

            if (e.Key == Key.Left)
            {
                (this.DataContext as BaseViewModel).LibraryViewModel.PreviousC(sender);
            }
        }
    }
}
