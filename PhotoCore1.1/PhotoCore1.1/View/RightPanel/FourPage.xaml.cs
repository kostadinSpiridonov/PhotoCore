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
    /// Interaction logic for FourPage.xaml
    /// </summary>
    public partial class FourPage : UserControl
    {
        public FourPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Show Posterization panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Posterization_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                PosterizationPanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).FourPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Monochrome panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Monochrome_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                MonochromePanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).FourPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Solarise panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Solarise_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                SolarControl.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Hidden;
                (this.DataContext as BaseViewModel).FourPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }
        /// <summary>
        /// Show Wrap panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Warp_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                MainButtons.Visibility = Visibility.Hidden;
                WarpPanel.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                PartImageButtons.Visibility = Visibility.Visible;
                (this.DataContext as BaseViewModel).FourPageEffects.Temporary = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                VisibilityProperties.Instance.ClearButtonVisibility = false;
            }
        }


        private void Part_Unchecked(object sender, RoutedEventArgs e)
        {
            WholeImageGr.IsChecked = true;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            PosterizationPanel.Visibility = Visibility.Hidden;
            MonochromePanel.Visibility = Visibility.Hidden;
            SolarControl.Visibility = Visibility.Hidden;
            WarpPanel.Visibility = Visibility.Hidden;
            MainButtons.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Hidden;
            PartImageButtons.Visibility = Visibility.Hidden;
            VisibilityProperties.Instance.ClearButtonVisibility = true;
        }
    }
}
