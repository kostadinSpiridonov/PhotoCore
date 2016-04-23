using PhotoCore1._1.Models;
using PhotoCore1._1.ViewModels;
using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PhotoCore1._1.View.RightPanel
{
    /// <summary>
    /// Interaction logic for ThirdPage.xaml
    /// </summary>
    public partial class ThirdPage : UserControl
    {
        public ThirdPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Show Water panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Water_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                WaterPanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).ThirdPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Pixel panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pixel_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                PixelletePanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).ThirdPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Cartoon panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cartoon_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                CartoonPanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).ThirdPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Round panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rounded_Corners_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                RoundedCorners.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Hidden;
                (this.DataContext as BaseViewModel).ThirdPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Channel rotate panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Channel_Rotate(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                ChannelRotatePanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).ThirdPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Oil panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Oil_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                OilPanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).ThirdPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Merge panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Merge_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                MergePanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Hidden;
                (this.DataContext as BaseViewModel).ThirdPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Hue panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hue_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                HuePanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Hidden;
                (this.DataContext as BaseViewModel).ThirdPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show all buttons panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainButtons.Visibility = Visibility.Visible;
            WaterPanel.Visibility = Visibility.Hidden;
            PixelletePanel.Visibility = Visibility.Hidden;
            CartoonPanel.Visibility = Visibility.Hidden;
            RoundedCorners.Visibility = Visibility.Hidden;
            HuePanel.Visibility = Visibility.Hidden;
            MergePanel.Visibility = Visibility.Hidden;
            OilPanel.Visibility = Visibility.Hidden;
            ChannelRotatePanel.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Hidden;
            PartImageButtons.Visibility = Visibility.Hidden;
            VisibilityProperties.Instance.ClearButtonVisibility = true;

        }

        private void Part_Unchecked(object sender, RoutedEventArgs e)
        {
            WholeImageGr.IsChecked = true;
        }
    }
}
