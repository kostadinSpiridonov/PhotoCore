using PhotoCore1._1.ViewModels;
using System;
using System.Collections.Generic;
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

namespace PhotoCore1._1.View.CollagesPatternViews
{
    /// <summary>
    /// Interaction logic for Five.xaml
    /// </summary>
    public partial class Five : UserControl
    {
        public Five()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Set data context whet the user control isvisible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_IsHitTestVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                (this.DataContext as BaseViewModel).CollageViewModel.Collage = this.Pattern;
            }
        }
    }
}
