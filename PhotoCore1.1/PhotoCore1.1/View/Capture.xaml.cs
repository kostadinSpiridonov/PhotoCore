using PhotoCore1._1.Models;
using PhotoCore1._1.StaticFunctionClasses;
using PhotoCore1._1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PhotoCore1._1.View
{
    /// <summary>
    /// Interaction logic for Capture.xaml
    /// </summary>
    public partial class Capture : Window
    {
        public Capture()
        {
            InitializeComponent();
        }
     
        private System.Windows.Point startCapturePoint = new System.Windows.Point();
    
        /// <summary>
        /// Set capture rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rectangle.Stroke = System.Windows.Media.Brushes.Red;
            rectangle.StrokeThickness = 1;
            rectangle.Visibility = Visibility.Hidden;
            startCapturePoint = e.GetPosition(CaptureWin);
            startCapturePoint.X = startCapturePoint.X - 7;
            startCapturePoint.Y = startCapturePoint.Y - 7;
            Canvas.SetZIndex(rectangle, CaptureCan.Children.Count);
            if (!CaptureCan.IsMouseCaptured)
                CaptureCan.CaptureMouse();

        }
       
        private int captureHeight=0;
       
        private int captureWidth = 0;
      
        /// <summary>
        /// Calculate start capture rectangle point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (CaptureCan.IsMouseCaptured)
            {
                CaptureCan.ReleaseMouseCapture();
            }
            rectangle.Stroke = System.Windows.Media.Brushes.Red;
            rectangle.StrokeThickness = 2;
            captureHeight = (int)rectangle.ActualHeight;
            captureWidth = (int)rectangle.ActualWidth;
            System.Windows.Point up = new System.Windows.Point();
            up = e.GetPosition(CaptureWin);
            startCapturePoint = ImageFunction.StartPointCalculate(up, startCapturePoint);
        }
        /// <summary>
        /// Resize capture rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            CaptureCan.Cursor = System.Windows.Input.Cursors.Cross;
            if (CaptureCan.IsMouseCaptured)
            {
                    System.Windows.Point currentPoint = e.GetPosition(CaptureWin);
                    if (currentPoint.X >= 0 && currentPoint.X <= CaptureWin.ActualWidth && currentPoint.Y >= 0 && currentPoint.Y <= CaptureWin.ActualHeight)
                    {
                        double x = startCapturePoint.X < currentPoint.X ? startCapturePoint.X : currentPoint.X;
                        double y = startCapturePoint.Y < currentPoint.Y ? startCapturePoint.Y : currentPoint.Y;
                        if (rectangle.Visibility == Visibility.Hidden)
                            rectangle.Visibility = Visibility.Visible;
                        rectangle.RenderTransform = new TranslateTransform(x, y);
                        rectangle.Width = Math.Abs(e.GetPosition(CaptureWin).X - startCapturePoint.X);
                        rectangle.Height = Math.Abs(e.GetPosition(CaptureWin).Y - startCapturePoint.Y);
                    }
                }
            }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        /// <summary>
        /// Copy capture rectangle to bitmap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Capture_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            if (this.captureHeight > 0 && this.captureWidth > 0)
            {
                Images.Instance.CurrentBitmap = ImageFunction.Capture(this.captureWidth, this.captureHeight, this.startCapturePoint);
                Images.Instance.NotifyImages();
                rectangle.Visibility = Visibility.Hidden;
                VisibilityProperties.Instance.NewListBorder = false;
                VisibilityProperties.Instance.NotifyProperties();
                UndoRedoModel.Instance.UndoStack = new Stack<System.Drawing.Bitmap>();
                UndoRedoModel.Instance.RedoStack = new Stack<System.Drawing.Bitmap>();
                Images.Instance.UndoBr = 0;
            }
            this.Close();
        }
    }
}
