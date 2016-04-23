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
    /// Interaction logic for MainPanel.xaml
    /// </summary>
    public partial class MainPanel : UserControl
    {
        public MainPanel()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, MouseButtonEventArgs e)
        {
            VisibilityProperties.Instance.RightPanel = false;
            VisibilityProperties.Instance.NotifyProperties();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
           try
            {  
                Bitmap r = (Bitmap)Images.Instance.OriginalBitmap.Clone();
                Images.Instance.CurrentBitmap = (Bitmap)r.Clone();
                Images.Instance.NotifyImages();
           }
            catch { }
        }

    }
}
