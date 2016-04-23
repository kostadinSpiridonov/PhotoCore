using PhotoCore1._1.Models;
using PhotoCore1._1.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhotoCore1._1.View.RightPanel
{
    /// <summary>
    /// Interaction logic for SecondPage.xaml
    /// </summary>
    public partial class SecondPage : UserControl
    {
        public SecondPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Show Change color panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeColor_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                RGBControl.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).SecondPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Sharpen panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sharpen_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                SharpenPanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).SecondPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Sepia panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sepia_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                SepiaPanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).SecondPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Tint panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tint_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                TintControl.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Hidden;
                (this.DataContext as BaseViewModel).SecondPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Smooth panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Smooth_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                SmoothPanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).SecondPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Emboss panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Emboss_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                EmbossPanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).SecondPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Edge panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edge_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                EdgePanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).SecondPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Jitter panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Jitter_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                JitterPanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).SecondPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }

        private void Part_Unchecked(object sender, RoutedEventArgs e)
        {
            WholeImageGr.IsChecked = true;
        }
        /// <summary>
        /// Show all buttons panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SharpenPanel.Visibility = Visibility.Hidden;
            SepiaPanel.Visibility = Visibility.Hidden;
            TintControl.Visibility = Visibility.Hidden;
            SmoothPanel.Visibility = Visibility.Hidden;
            EmbossPanel.Visibility = Visibility.Hidden;
            EdgePanel.Visibility = Visibility.Hidden;
            JitterPanel.Visibility = Visibility.Hidden;
            RGBControl.Visibility = Visibility.Hidden;
            MainButtons.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Hidden;
            PartImageButtons.Visibility = Visibility.Hidden;
            VisibilityProperties.Instance.ClearButtonVisibility = true;
        }

        private void Picker_Checked(object sender, RoutedEventArgs e)
        {
            VisibilityProperties.Instance.ImageCursor = Cursors.UpArrow;
            VisibilityProperties.Instance.PickerSelected = true;
            VisibilityProperties.Instance.NotifyProperties();
        }

        private void Picker_Unchecked(object sender, RoutedEventArgs e)
        {
            VisibilityProperties.Instance.ImageCursor = Cursors.Hand;
            VisibilityProperties.Instance.PickerSelected = false;
            VisibilityProperties.Instance.NotifyProperties();
        }

        private void PartImageGr_Checked(object sender, RoutedEventArgs e)
        {
            SecondPicker.IsChecked = false;
        }
    }
}
