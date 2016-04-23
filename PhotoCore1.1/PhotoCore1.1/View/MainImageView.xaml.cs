using PhotoCore1._1.Models;
using PhotoCore1._1.StaticFunctionClasses;
using PhotoCore1._1.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
namespace PhotoCore1._1.View
{
    /// <summary>
    /// Interaction logic for MainImageView.xaml
    /// </summary>
    public partial class MainImageView : UserControl
    {
        public MainImageView()
        {
            InitializeComponent();
            TopPanel.Click += new EventHandler(SetDrawingAtributes);
            TopPanel.TextStyles += new EventHandler(SetTextStyle);
        }
        /// <summary>
        /// Set and move paste image
        /// </summary>
        #region ImagesSet
        int index=0;
        private void Sel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (VisibilityProperties.Instance.SelectCanvasVisibility == true && Images.Instance.CurrentBitmap != null)
            {
                if (Images.Instance.SelectedBitmap == null)
                {
                    rectangle.Stroke = System.Windows.Media.Brushes.Black;
                    rectangle.StrokeThickness = 1;
                    VisibilityProperties.Instance.SelectRectangleVisibility = false;
                    VisibilityProperties.Instance.NotifyProperties();
                    SelectedPoints.PointDown = e.GetPosition(ImageOp);
                    Canvas.SetZIndex(rectangle, SelectionCanvas.Children.Count);
                    if (!SelectionCanvas.IsMouseCaptured)
                        SelectionCanvas.CaptureMouse();
                    index = 1;
                }
                else
                {
                    SelectedPoints.PointDown = e.GetPosition(ImageOp);
                    Canvas.SetZIndex(rectangle, SelectionCanvas.Children.Count);
                    VisibilityProperties.Instance.SelectRectangleVisibility = false;
                    VisibilityProperties.Instance.NotifyProperties();
                    Images.Instance.SelectedBitmap = null;
                    Images.Instance.NotifyImages();
                    index = 0;
                }
            }
        }

        private void CanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (VisibilityProperties.Instance.SelectCanvasVisibility == true && Images.Instance.CurrentBitmap != null)
            {
                if (SelectionCanvas.IsMouseCaptured)
                {
                    SelectionCanvas.ReleaseMouseCapture();
                }
                double x = 0;
                double y = 0;
                SelectedPoints.PointUp = e.GetPosition(ImageOp);
                if (SelectedPoints.PointUp.X >= 0)
                {
                    x = SelectedPoints.PointUp.X;
                }
                else if (SelectedPoints.PointUp.X < 0)
                {
                    x = 0;
                }
                if (SelectedPoints.PointUp.Y >= 0)
                {
                    y = SelectedPoints.PointUp.Y;
                }
                else if (SelectedPoints.PointUp.Y < 0)
                {
                    y = 0;
                }
                SelectedPoints.PointUp = new System.Windows.Point(x, y);
                rectangle.Stroke = System.Windows.Media.Brushes.Blue;
                rectangle.StrokeThickness = 2;
                if (index == 1&&rectangle.ActualHeight>0&&rectangle.ActualWidth>0)
                {
                    ImageFunction.CopySelectedAreaToBitmap((int)rectangle.ActualWidth, (int)rectangle.ActualHeight, SelectedPoints.PointUp, SelectedPoints.PointDown);
                }
                index = 0;
            }
        }

        private void CanvasMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (VisibilityProperties.Instance.SelectCanvasVisibility == true && Images.Instance.CurrentBitmap != null)
            {
                SelectionCanvas.Cursor = System.Windows.Input.Cursors.Cross;
                if (SelectionCanvas.IsMouseCaptured)
                {
                    try
                    {
                        System.Windows.Point currentPoint = e.GetPosition(ImageOp);
                        if (currentPoint.X >= 0 && currentPoint.X <= ImageOp.ActualWidth && currentPoint.Y >= 0 && currentPoint.Y <= ImageOp.ActualHeight)
                        {
                            double x = SelectedPoints.PointDown.X < currentPoint.X ? SelectedPoints.PointDown.X : currentPoint.X;
                            double y = SelectedPoints.PointDown.Y < currentPoint.Y ? SelectedPoints.PointDown.Y : currentPoint.Y;
                            if (VisibilityProperties.Instance.SelectRectangleVisibility == false)
                            {
                                VisibilityProperties.Instance.SelectRectangleVisibility = true;
                                VisibilityProperties.Instance.NotifyProperties();
                            }
                            rectangle.RenderTransform = new TranslateTransform(x, y);
                            rectangle.Width = Math.Abs(e.GetPosition(SelectionCanvas).X - SelectedPoints.PointDown.X);
                            rectangle.Height = Math.Abs(e.GetPosition(SelectionCanvas).Y - SelectedPoints.PointDown.Y);
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        System.Windows.Point one = new System.Windows.Point();
        System.Windows.Point two = new System.Windows.Point();
        private void MovePasteImage(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && MergeImage.IsMouseOver == true)
            {
                two = e.GetPosition(MergeCanvas);
                one.X = Canvas.GetLeft(MergeImage) + MergeImage.ActualWidth / 2;
                one.Y = Canvas.GetTop(MergeImage) + MergeImage.ActualHeight / 2;
                Canvas.SetLeft(MergeImage, Canvas.GetLeft(MergeImage) + (two.X - one.X));
                Canvas.SetTop(MergeImage, Canvas.GetTop(MergeImage) + (two.Y - one.Y));
            }
        }

        private void SetImageMerge(object sender, MouseButtonEventArgs e)
        {
            if (one.X + MergeImage.ActualWidth / 2 > ImageOp.ActualWidth)
            {
                Canvas.SetLeft(MergeImage, Images.Instance.CurrentBitmap.Width - MergeImage.ActualWidth);
            }
            if (one.Y + MergeImage.ActualHeight / 2 > Images.Instance.CurrentBitmap.Height)
            {
                Canvas.SetTop(MergeImage, Images.Instance.CurrentBitmap.Height - MergeImage.ActualHeight);
            }
            if (one.X - MergeImage.ActualWidth / 2 < 0)
            {
                Canvas.SetLeft(MergeImage, 0);
            }
            if (one.Y - MergeImage.ActualHeight / 2 < 0)
            {
                Canvas.SetTop(MergeImage, 0);
            }

            Vector vec = VisualTreeHelper.GetOffset(MergeImage);
            if(vec.X<0)
            {
                vec.X = 0;
            }
            if(vec.Y<0)
            {
                vec.Y = 0;
            }
            if (vec.X > ImageOp.ActualWidth - MergeImage.ActualWidth - 1)
            {
                vec.X = ImageOp.ActualWidth-MergeImage.ActualWidth;
            }
            if (vec.Y > ImageOp.ActualHeight - MergeImage.ActualHeight - 1)
            {
                vec.Y = ImageOp.ActualHeight-MergeImage.ActualHeight;
            }
            SelectedPoints.MergePoint = new System.Windows.Point(vec.X, vec.Y);
        }

        private static int activity=0;
        public static int Avtivity
        {
            get
            {
                return activity;
            }
            set
            {
                activity = value;
            }
        }
        private void SetPasteImage(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (MergeCanvas.Visibility == Visibility.Visible)
                {
                    if (Avtivity == 0)
                    {
                        if (MergeImage.IsMouseOver == false)
                        {
                            Vector vec = VisualTreeHelper.GetOffset(MergeImage);
                            if (Images.Instance.PasteBitmap.Height < Images.Instance.CurrentBitmap.Height)
                            {
                                if (Images.Instance.PasteBitmap.Width < Images.Instance.CurrentBitmap.Width)
                                {
                                    Bitmap temp = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                                    Graphics newImage = Graphics.FromImage(temp);
                                    newImage.DrawImage(Images.Instance.PasteBitmap, (int)vec.X + 3, (int)vec.Y + 3, Images.Instance.PasteBitmap.Width, Images.Instance.PasteBitmap.Height);
                                    Images.Instance.CurrentBitmap = (Bitmap)temp.Clone();
                                }
                            }
                            else
                            {
                                System.Windows.MessageBox.Show(PhotoCore1._1.Models.Language.CurrentLanguage[17]);
                            }
                            VisibilityProperties.Instance.PastePanelVisibility = false;
                            VisibilityProperties.Instance.NotifyProperties();
                            Images.Instance.PasteBitmap = null;
                            Images.Instance.NotifyImages();
                        }
                    }
                }
            }
            catch { }
        }
        public static event EventHandler OpenInEFr;
        #endregion
      
        #region PickerColor
        /// <summary>
        /// Set picker color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FunctiosClick(object sender, MouseButtonEventArgs e)
        {
            if (VisibilityProperties.Instance.PickerSelected == true)
            {
                if (e.ButtonState == MouseButtonState.Pressed)
                {
                    System.Drawing.Color m = Images.Instance.CurrentBitmap.GetPixel((int)e.GetPosition(ImageOp).X, (int)e.GetPosition(ImageOp).Y);
                    ColorsViewModel.colors.RemoveAt(ColorsViewModel.colors.Count - 1);
                    ColorsViewModel.colors.Add(new ColorModel(m));
                    OpenInEFr(sender, e);
                }
            }
        }
        #endregion
        /// <summary>
        /// Set drawing styles
        /// </summary>
        /// <param name="aSender"></param>
        /// <param name="aEventArgs"></param>
        public void SetDrawingAtributes(object aSender,EventArgs aEventArgs)
        {
            if (VisibilityProperties.Instance.InkCanvasVisibility == true)
            {
                var a = aSender as System.Windows.Media.Brush;
                SolidColorBrush newBrush = (SolidColorBrush)a;
                var result = System.Windows.Media.ColorConverter.ConvertFromString(a.ToString());
                InkCan.DefaultDrawingAttributes.Color = (System.Windows.Media.Color)result;
            }
        }
        public static int check=1;
        private void paintSurface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (VisibilityProperties.Instance.TextButtonChecked == true &&
                VisibilityProperties.Instance.InsertTextVisibility == false &&
                Images.Instance.CurrentBitmap != null&&check==1)
            {
                SelectedPoints.TextBoxPoint = e.GetPosition(ImageOp);
                if (SelectedPoints.TextBoxPoint.X > 0 && SelectedPoints.TextBoxPoint.Y > 0&&
                    SelectedPoints.TextBoxPoint.X < ImageOp.Width - 10 - TextBoxInsertText.ActualWidth && SelectedPoints.TextBoxPoint.Y < ImageOp.ActualHeight - 20&&
                    check==1)
                {
                    
                    if(VisibilityProperties.Instance.TextButtonChecked==true)
                    {
                        VisibilityProperties.Instance.TextPanelIsSelected = true;
                        VisibilityProperties.Instance.NotifyProperties();
                    }
        
                    TextBoxInsertText.IsEnabled = true;
                    VisibilityProperties.Instance.InsertTextVisibility = true;
                    VisibilityProperties.Instance.NotifyProperties();
                    Canvas.SetTop(TextBoxInsertText, SelectedPoints.TextBoxPoint.Y);
                    Canvas.SetLeft(TextBoxInsertText, SelectedPoints.TextBoxPoint.X);
                    TextBoxInsertText.Focusable = true;
                    TextBoxInsertText.Width = Double.NaN;
                    TextBoxInsertText.Height = Double.NaN;
                    if (TextBoxInsertText.IsFocused == false)
                    {
                        Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, (System.Threading.ThreadStart)delegate()
                        {
                            TextBoxInsertText.Focus();
                        });
                    }
                    check = 2;
                }
            }
        }
        /// <summary>
        /// Left button click events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageOp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed && VisibilityProperties.Instance.InsertTextVisibility == true &&
                VisibilityProperties.Instance.TextButtonChecked == true && check == 2 && TextBoxInsertText.Text != null)
            {
                if (ImageOp.IsMouseOver == true)
                {
                    TextBoxInsertText.IsEnabled = false;
                }
                Images.Instance.CurrentBitmap = ImageConverterFormat.GetBitmapFromSource(ImageConverterFormat.ConvertToBitmapSource(ImageGrid));
                Images.Instance.NotifyImages();
                TextBoxInsertText.Text = null;
                VisibilityProperties.Instance.InsertTextVisibility = false;
                VisibilityProperties.Instance.NotifyProperties();
                
                if(VisibilityProperties.Instance.TextButtonChecked==true)
                {
                    VisibilityProperties.Instance.HomePanelIsSelected = true;
                    VisibilityProperties.Instance.NotifyProperties();
                }
            }
            else
            {
                check = 1;
            }
        }
        /// <summary>
        /// Insert text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxInsertText_KeyDown(object sender, KeyEventArgs e)
        {
            double r;
            double b;
            r = SelectedPoints.TextBoxPoint.X + TextBoxInsertText.ActualWidth;
            b = SelectedPoints.TextBoxPoint.Y + TextBoxInsertText.ActualHeight;
            if (r > ImageTextCanvas.ActualWidth-10)
            {
                try
                {
                    TextBoxInsertText.Width = TextBoxInsertText.ActualWidth;
                }
                catch { }
            }
            if (b > ImageTextCanvas.ActualHeight-10)
            {
                try
                {
                    TextBoxInsertText.Text = TextBoxInsertText.Text.Remove(TextBoxInsertText.Text.Length - 1);
                    TextBoxInsertText.Text = TextBoxInsertText.Text.Remove(TextBoxInsertText.Text.Length - 1);
                    TextBoxInsertText.Height = Double.NaN;
                }
                catch { }

            }
            try
            {
                TextBoxInsertText.Select(TextBoxInsertText.Text.Length, 0);
            }
            catch { }
        }
         /// <summary>
         /// Set text styles
         /// </summary>
        #region TextBoxStyles
        int under = 0;
        int strike = 0;
        System.Windows.Ink.DrawingAttributes inkDA = new System.Windows.Ink.DrawingAttributes();
        private void SetTextStyle(object aSender,EventArgs aEventArgs)
        {
            string a = (aSender).ToString();
            if (a == "1")
            {
                TextBoxInsertText.FontWeight = FontWeights.Bold;
            }
            if (a == "-1")
            {
                TextBoxInsertText.FontWeight = FontWeights.Normal;
            }
            if (a == "2")
            {
                TextBoxInsertText.SetValue(TextElement.FontStyleProperty, FontStyles.Italic);
            }
            if (a == "-2")
            {
                TextBoxInsertText.SetValue(TextElement.FontStyleProperty, FontStyles.Normal);
            }
            if (a =="3")
            {
                if (strike==1)
                {
                    TextDecorationCollection textDecor = new TextDecorationCollection();
                    textDecor.Add(TextDecorations.Strikethrough);
                    textDecor.Add(TextDecorations.Underline);
                    TextBoxInsertText.TextDecorations = textDecor;
                    under = 1;
                }
                else
                {
                    TextDecorationCollection textDecor = new TextDecorationCollection();
                    textDecor.Add(TextDecorations.Underline);
                    TextBoxInsertText.TextDecorations = textDecor;
                    under = 1;
                }
            }
            if (a == "-3")
            {
                if (strike==1)
                {
                    TextDecorationCollection textDecor = new TextDecorationCollection();
                    textDecor.Add(TextDecorations.Strikethrough);
                    TextBoxInsertText.TextDecorations = textDecor;
                    under = 0;

                }
                else
                {
                    TextBoxInsertText.TextDecorations = null;
                    under=0;
                    strike=0;
                }
            }
            if (a == "4")
            {
                if (under==1)
                {
                    TextDecorationCollection textDecor = new TextDecorationCollection();
                    textDecor.Add(TextDecorations.Strikethrough);
                    textDecor.Add(TextDecorations.Underline);
                    TextBoxInsertText.TextDecorations = textDecor;
                    strike = 1;
                }
                else
                {
                    TextDecorationCollection textDecor = new TextDecorationCollection();
                    textDecor.Add(TextDecorations.Strikethrough);
                    TextBoxInsertText.TextDecorations = textDecor;
                    strike = 1;
                }
            }
            if (a == "-4")
            {
                if (under==1)
                {
                    TextDecorationCollection textDecor = new TextDecorationCollection();
                    textDecor.Add(TextDecorations.Underline);
                    TextBoxInsertText.TextDecorations = textDecor;
                    strike = 0;
                }
                else
                {
                    TextBoxInsertText.TextDecorations = null;
                    under = 0;
                    strike = 0;
                }
            }
            if (a == "TH1")
            {
                inkDA.Height = 5;
                inkDA.Width = 5;
                InkCan.DefaultDrawingAttributes = inkDA;
            }
            if (a == "TH2")
            {
                inkDA.Height = 15;
                inkDA.Width = 15;
                InkCan.DefaultDrawingAttributes = inkDA;
            }
            if (a == "TH3")
            {
                inkDA.Height = 25;
                inkDA.Width = 25;
                InkCan.DefaultDrawingAttributes = inkDA;
            }
            if (a == "TH4")
            {
                inkDA.Height = 35;
                inkDA.Width = 35;
                InkCan.DefaultDrawingAttributes = inkDA;
            }
        }
        #endregion

        private void ClearSelectedData(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(rectangle.Visibility==Visibility.Hidden)
            {
                Images.Instance.SelectedBitmap = null;
                Images.Instance.NotifyImages();
            }
        }

        /// <summary>
        /// Zoom control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zoom_Plus_Click(object sender, RoutedEventArgs e)
        {
               if (sldZoom.Value < 2)
            {
                sldZoom.Value = sldZoom.Value * 2;
            }
            else
            {
                sldZoom.Value = sldZoom.Value + 1;
            }
        }

        private void Zoom_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (sldZoom.Value < 2)
            {
                sldZoom.Value = sldZoom.Value / 2;
            }
            else
            {
                sldZoom.Value = sldZoom.Value - 1;
            }
        }

    }
}
