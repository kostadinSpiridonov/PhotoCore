using MahApps.Metro;
using PhotoCore1._1.Models;
using PhotoCore1._1.StaticFunctionClasses;
using PhotoCore1._1.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

namespace PhotoCore1._1.View
{
    /// <summary>
    /// Interaction logic for TopPanel.xaml
    /// </summary>
    public partial class TopPanel : UserControl
    {
        int olderIndex;
        public TopPanel()
        {
            InitializeComponent();
            int index=8;
            StreamReader reader = new StreamReader("../../Resources/WindowColor.txt");
            index=int.Parse(reader.ReadLine().ToString());
            index--;
            ThemesWindowsListView.SelectedIndex = index;
            reader.Close();
        }
        #region Functions
        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            (sender as System.Windows.Controls.Button).ContextMenu.IsEnabled = true;
            (sender as System.Windows.Controls.Button).ContextMenu.PlacementTarget = (sender as System.Windows.Controls.Button);
            (sender as System.Windows.Controls.Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as System.Windows.Controls.Button).ContextMenu.IsOpen = true;
        }

        private void ChangeMain(object sender, DataTransferEventArgs e)
        {
            this.ListViewNames.SelectedIndex = ListViewNames.AlternationCount - 1;
        }

        public void ChangeRec(object sender, EventArgs e)
        {
            this.ListViewNames.SelectedIndex = ColorsViewModel.colors.Count - 1;
        }

        private void ListViewNames_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainImageView.OpenInEFr += new EventHandler(ChangeRec);
        }
        #endregion
        #region ToggleButtons
        /// <summary>
        /// Picker checked and unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChPic(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
              Picker.IsChecked = false;
            }
            else
            {
                VisibilityProperties.Instance.TextButtonChecked = false;
                VisibilityProperties.Instance.InkCanvasVisibility = false;
                VisibilityProperties.Instance.PickerSelected = true;
                VisibilityProperties.Instance.SelectCanvasVisibility = false;
                VisibilityProperties.Instance.NotifyProperties();
                Drawbut.IsChecked = false;
                Select_Piece.IsChecked = false;
                Eraser.IsChecked = false;
                Text.IsChecked = false;
            }
            VisibilityProperties.Instance.ImageCursor = Cursors.UpArrow;
        }
        private void Picker_Unchecked(object sender, RoutedEventArgs e)
        {
            VisibilityProperties.Instance.PickerSelected = false;
            VisibilityProperties.Instance.NotifyProperties();
            VisibilityProperties.Instance.ImageCursor = Cursors.Arrow;
        }

        /// <summary>
        /// Pen checked and unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Drawbut_Checked(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
              Drawbut.IsChecked = false;
            }
            else
            {
                VisibilityProperties.Instance.TextButtonChecked = false;
                VisibilityProperties.Instance.InkCanvasVisibility = true;
                VisibilityProperties.Instance.PickerSelected = false;
                VisibilityProperties.Instance.SelectCanvasVisibility = false;
                VisibilityProperties.Instance.NotifyProperties();
                Picker.IsChecked = false;
                Select_Piece.IsChecked = false;
                Eraser.IsChecked = false;
                Text.IsChecked = false;
            }
            VisibilityProperties.Instance.ImageCursor = Cursors.Pen;
        }
        private void Drawbut_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Eraser.IsChecked == false)
            {
                VisibilityProperties.Instance.InkCanvasVisibility = false;
                VisibilityProperties.Instance.NotifyProperties();
            }
            VisibilityProperties.Instance.ImageCursor = Cursors.Arrow;
        }

        /// <summary>
        /// Select checked and unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_Piece_Unchecked(object sender, RoutedEventArgs e)
        {
            VisibilityProperties.Instance.SelectCanvasVisibility = false;
            VisibilityProperties.Instance.NotifyProperties();
            VisibilityProperties.Instance.ImageCursor = Cursors.Arrow;
        }
        private void Select_Checked(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
              Select_Piece.IsChecked = false;
            }
            else
            {
                VisibilityProperties.Instance.TextButtonChecked = false;
                VisibilityProperties.Instance.InkCanvasVisibility = false;
                VisibilityProperties.Instance.PickerSelected = false;
                VisibilityProperties.Instance.SelectCanvasVisibility = true;
                VisibilityProperties.Instance.NotifyProperties();
                Drawbut.IsChecked = false;
                Picker.IsChecked = false;
                Eraser.IsChecked = false;
                Text.IsChecked = false;
            }
            VisibilityProperties.Instance.ImageCursor = Cursors.Cross;
        }

        /// <summary>
        /// Eraser checked and unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eraser_Checked(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
              Eraser.IsChecked = false;
            }
            else
            {
                VisibilityProperties.Instance.TextButtonChecked = false;
                VisibilityProperties.Instance.InkCanvasVisibility = true;
                VisibilityProperties.Instance.PickerSelected = false;
                VisibilityProperties.Instance.SelectCanvasVisibility = false;
                VisibilityProperties.Instance.NotifyProperties();
                Drawbut.IsChecked = false;
                Picker.IsChecked = false;
                Select_Piece.IsChecked = false;
                olderIndex = ListViewNames.SelectedIndex;
                ListViewNames.SelectedIndex = 8;
                Text.IsChecked = false;
            }
            VisibilityProperties.Instance.ImageCursor = Cursors.ScrollNE;
        }
        private void Eraser_Unchecked(object sender, RoutedEventArgs e)
        {
            if (olderIndex >= 0)
            {
                ListViewNames.SelectedIndex = olderIndex;
            }
            else
            {
                ListViewNames.SelectedIndex = 0;
            }
            VisibilityProperties.Instance.ImageCursor = Cursors.Arrow;
        }

        /// <summary>
        /// Text checked and unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextButtonChecked(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
              System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
              Text.IsChecked = false;
            }
            else
            {
                VisibilityProperties.Instance.TextButtonChecked = true;
                VisibilityProperties.Instance.InkCanvasVisibility = false;
                VisibilityProperties.Instance.PickerSelected = false;
                VisibilityProperties.Instance.SelectCanvasVisibility = false;
                VisibilityProperties.Instance.NotifyProperties();
                Drawbut.IsChecked = false;
                Picker.IsChecked = false;
                Select_Piece.IsChecked = false;
                Text.IsChecked = true;
                Eraser.IsChecked = false;
                MainImageView.check = 1;
            }
            VisibilityProperties.Instance.ImageCursor = Cursors.Arrow;
        }
        private void Text_Unchecked(object sender, RoutedEventArgs e)
        {
            VisibilityProperties.Instance.TextButtonChecked = false;
            VisibilityProperties.Instance.NotifyProperties();
        }

        #endregion

        public static event EventHandler Click;
        private void ListViewNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Click(RecCol.Fill, e);
        }
        /// <summary>
        /// Text style button checked and uchecked
        /// </summary>
        #region TextStyles
        public static EventHandler TextStyles;
        private void Bold_Checked(object sender, RoutedEventArgs e)
        {
            TextStyles(1, e);
        }

        private void Bold_Unchecked(object sender, RoutedEventArgs e)
        {
            TextStyles(-1, e);
        }

        private void Italic_Checked(object sender, RoutedEventArgs e)
        {
            TextStyles(2, e);
        }

        private void Italic_Unchecked(object sender, RoutedEventArgs e)
        {
            TextStyles(-2, e);
        }

        private void Underline_Checked(object sender, RoutedEventArgs e)
        {
            TextStyles(3, e);
        }

        private void Underline_Unchecked(object sender, RoutedEventArgs e)
        {
            TextStyles(-3, e);
        }

        private void Strikeout_Checked(object sender, RoutedEventArgs e)
        {
            TextStyles(4, e);
        }

        private void Strikeout_Unchecked(object sender, RoutedEventArgs e)
        {
            TextStyles(-4, e);
        }

        private void ThicknessChoose(object sender, RoutedEventArgs e)
        {
            var a = sender as MenuItem;
            TextStyles(a.Name, e);
        }
        #endregion

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           ThemeManager.ChangeTheme(App.Current, ThemeManager.DefaultAccents[ThemesWindowsListView.SelectedIndex+1],Theme.Light);
           StreamWriter writer = new StreamWriter("../../Resources/WindowColor.txt", false);
           writer.Write((ThemesWindowsListView.SelectedIndex + 1).ToString());
           writer.Close();
           try
           {
               (this.DataContext as BaseViewModel).ColorsViewModel.ThemeColor = (ThemesWindowsListView.SelectedItem as ColorModel).BrushColor;
           }
           catch { }
        }
     
        #region Library
        /// <summary>
        /// Show library
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Library_Open(object sender, RoutedEventArgs e)
        {
             Library lib;
             lib= new Library();
             lib.DataContext = this.DataContext;
             lib.SetContent(ImageFunction.CreateListFromTwoStackAndBitmap(UndoRedoModel.Instance.UndoStack, UndoRedoModel.Instance.RedoStack, Images.Instance.CurrentBitmap));
             lib.ShowDialog();
        }
        #endregion
        /// <summary>
        /// Show capture window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Capture_Click(object sender, RoutedEventArgs e)
        {
            Capture cap;
            cap = new Capture();
            cap.DataContext = this.DataContext;
            cap.ShowDialog();
        }
        /// <summary>
        /// Show collage widnow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateCollage_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Collage col;
            col = new Collage();
            col.DataContext = this.DataContext;
            col.ShowDialog();
            this.Cursor = Cursors.Arrow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VisibilityProperties.Instance.RightPanel = true;
            VisibilityProperties.Instance.NotifyProperties();
        }
        /// <summary>
        /// Show frames
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frames_Click(object sender, RoutedEventArgs e)
        {
            Frames frames;
            frames = new Frames();
            frames.DataContext = this.DataContext;
            frames.ShowDialog();
        }
        /// <summary>
        /// Show resize window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResizeOpen_Click(object sender, RoutedEventArgs e)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
                System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[95]);
            }
            else
            {
                Resize reswin = new Resize();
                reswin = new Resize();
                reswin.DataContext = this.DataContext;
                reswin.Visibility = Visibility.Visible;
            }
        }

    }
}
