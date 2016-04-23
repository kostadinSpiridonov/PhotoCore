using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PhotoCore1._1.View
{
    /// <summary>
    /// Interaction logic for FullScreen.xaml
    /// </summary>
    public partial class FullScreen : Window
    {
        public FullScreen()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Set fulscreen image
        /// </summary>
        /// <param name="image"></param>
        public void SetImage(BitmapImage image)
        {
            try
            {
                FullscreenImage.Source = image;
            }
            catch { }
        }
        private void CloseFullscreen(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
