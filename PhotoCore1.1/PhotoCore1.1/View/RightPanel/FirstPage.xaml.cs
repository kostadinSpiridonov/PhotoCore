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
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : UserControl
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show Brightness panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Brightness_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
                System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                BrigthnessControl.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).FirstPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Contrast panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Contrast_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
                System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                ContrastControl.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).FirstPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Gamma panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gama_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
                System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                GammaControl.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).FirstPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Grayscale panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grayskale_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
                System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                GrayscalePanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).FirstPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Invert panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Invert_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
                System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                InvertPanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).FirstPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Swirl panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Swirl_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
               System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                SwirlPanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).FirstPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Sphere panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sphere_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                SpherePanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).FirstPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
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
            BrigthnessControl.Visibility = Visibility.Hidden;
            ContrastControl.Visibility = Visibility.Hidden;
            GammaControl.Visibility = Visibility.Hidden;
            GrayscalePanel.Visibility = Visibility.Hidden;
            InvertPanel.Visibility = Visibility.Hidden;
            SwirlPanel.Visibility = Visibility.Hidden;
            SpherePanel.Visibility = Visibility.Hidden;
            MedianControl.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Hidden;
            PartImageButtons.Visibility = Visibility.Hidden;
            VisibilityProperties.Instance.ClearButtonVisibility = true;
        }
        /// <summary>
        /// Show Median panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Median_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                MedianControl.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).FirstPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }

        private void Part_Unchecked(object sender, RoutedEventArgs e)
        {
            WholeImageGr.IsChecked = true;
        }

    }
}
