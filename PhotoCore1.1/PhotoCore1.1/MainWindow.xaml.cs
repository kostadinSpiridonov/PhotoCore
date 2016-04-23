using PhotoCore1._1.Models;
using PhotoCore1._1.StaticFunctionClasses;
using PhotoCore1._1.View;
using PhotoCore1._1.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhotoCore1._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closed += new System.EventHandler(WindowClose);
            Bitmap a = ImageFunction.NewImage();
            a.SetPixel(0, 0, a.GetPixel(0, 0));
            Images.Instance.CurrentBitmap = a;
            Images.Instance.NotifyImages();
            StreamWriter writer = new StreamWriter("../../Resources/WindowColor.txt", false);
            writer.Write(6);
            writer.Close();
        }
        #region Exit
        /// <summary>
        /// Exit question about saving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, CancelEventArgs e)
        {
            Images.Instance.ChangeSum--;
            if (Images.Instance.ChangeSum == 0)
            {
                System.Windows.Application.Current.Shutdown();
            }
            else
            {
                if (Images.Instance.ChangeSum > 0)
                {
                    switch (System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[30], "PhotoCore", MessageBoxButton.YesNoCancel))
                    {

                            case MessageBoxResult.No:
                                {
                                    System.Windows.Application.Current.Shutdown();
                                    break;
                                }
                            case MessageBoxResult.Cancel:
                                {
                                    e.Cancel = true;
                                    Images.Instance.ChangeSum++;
                                    break;
                                }
                        case MessageBoxResult.Yes:
                            {
                                if (File.Exists(Images.Instance.BitmapPath))
                                {
                                    Images.Instance.DrawFrame();
                                    ImageFunction.SaveCurrentImage(Images.Instance.CurrentBitmap, Images.Instance.BitmapPath);
                                }
                                else
                                {
                                    Images.Instance.DrawFrame();
                                    SaveFileDialog s = new SaveFileDialog();
                                    s.Filter = "Png files|*.png|Jpeg files|*.jpeg|Bitmaps|*.bmp|Jpg files|*.jpg";
                                    s.FileName = "Untitled";
                                    if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        try
                                        {
                                            if (File.Exists(s.FileName))
                                            {
                                                File.Delete(s.FileName);
                                            }
                                            if (s.FileName.Contains(".jpeg"))
                                            {
                                                Images.Instance.CurrentBitmap.Save(s.FileName, ImageFormat.Jpeg);
                                            }
                                            else if (s.FileName.Contains(".png"))
                                            {
                                                Images.Instance.CurrentBitmap.Save(s.FileName, ImageFormat.Png);
                                            }
                                            else if (s.FileName.Contains(".bmp"))
                                            {
                                                Images.Instance.CurrentBitmap.Save(s.FileName, ImageFormat.Bmp);
                                            }
                                                
                                        }
                                        catch { }
                                        Images.Instance.ChangeSum = 0;
                                    }
                                    else
                                    {

                                        e.Cancel = true; 
                                        Images.Instance.ChangeSum++;
                                    }
                                 }
                            break;
                         }
                   }
               }
           }
        }
        #endregion
        private void WindowClose(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        /// <summary>
        /// Resize the grid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPanel_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(VisibilityProperties.Instance.RightPanel==true)
            {
                Grid.SetColumnSpan(MainImage, 1);
            }
            else
            {
                Grid.SetColumnSpan(MainImage, 2);
            }
        }
        /// <summary>
        /// Open help file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Help_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Path.Combine(Environment.CurrentDirectory, "../..//Help/HelpPhotoCore.chm"));
        }
        /// <summary>
        /// Set key combinations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyCombinations(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                (this.DataContext as BaseViewModel).TopPanelViewModel.CopyC(sender);
            }

            if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
            {
                (this.DataContext as BaseViewModel).TopPanelViewModel.PasteC(sender);
            }

            if (e.Key == Key.X && Keyboard.Modifiers == ModifierKeys.Control)
            {
                (this.DataContext as BaseViewModel).TopPanelViewModel.CutC(sender);
            }

            if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                (this.DataContext as BaseViewModel).TopPanelViewModel.SaveImage(sender);
            }

            if (e.Key == Key.Z && Keyboard.Modifiers == ModifierKeys.Control)
            {
                (this.DataContext as BaseViewModel).TopPanelViewModel.UndoC(sender);
            }

            if (e.Key == Key.R && Keyboard.Modifiers == ModifierKeys.Control)
            {
                (this.DataContext as BaseViewModel).TopPanelViewModel.RedoC(sender);
            }
            if (e.Key == Key.F1)
            {
                Help_Click(sender, e);

            }
        }
    }
}
