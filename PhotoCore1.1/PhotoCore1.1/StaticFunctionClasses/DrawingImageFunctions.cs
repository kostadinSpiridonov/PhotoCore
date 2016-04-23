using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoCore1._1.StaticFunctionClasses
{
    public static class DrawingImageFunctions
    {
        /// <summary>
        /// Stroke Collection to Canvas
        /// </summary>
        /// <param name="strokeCol"></param>
        /// <param name="dWidth"></param>
        /// <param name="dHeight"></param>
        /// <returns></returns>
        public static Canvas InkToXamlGeom(StrokeCollection strokeCol,
                                  double dWidth, double dHeight)
        {
            Geometry oGeom;
            System.Windows.Shapes.Path oPath;
            Canvas panel = new Canvas();
            panel.Width = dWidth;
            panel.Height = dHeight;
            panel.Background = System.Windows.Media.Brushes.White;
            int strokeNumber = -1;
            string strokeName = "";
            foreach (System.Windows.Ink.Stroke inkStroke in strokeCol)
            {
                strokeNumber += 1;
                strokeName = strokeNumber.ToString().PadLeft(4, '0');
                oPath = new System.Windows.Shapes.Path();
                oPath.Name = "Stroke_" + strokeName;
                oPath.Stroke = new SolidColorBrush(inkStroke.DrawingAttributes.Color);
                oPath.Fill = new SolidColorBrush(inkStroke.DrawingAttributes.Color);
                oGeom = (inkStroke.GetGeometry(inkStroke.DrawingAttributes));
                oPath.Data = oGeom;
                panel.Children.Add(oPath);
            }
            return panel;
        }
        /// <summary>
        /// Get BitmapSource from canvas
        /// </summary>
        public static BitmapSource BuildImage(Canvas canvas, System.Windows.Size a)
        {
            System.Windows.Size size = a;
            canvas.Measure(size);
            canvas.Arrange(new Rect(size));

            RenderTargetBitmap image = new RenderTargetBitmap(
                (int)size.Width,
                (int)size.Height,
                96,
                96,
                PixelFormats.Pbgra32);

            image.Render(canvas);


            return image;
        }
        /// <summary>
        /// Get bitmap from BitmapSource
        /// </summary>
        public static Bitmap GetBitmap(BitmapSource source)
        {
            Bitmap bmp = new Bitmap
            (
              source.PixelWidth,
              source.PixelHeight,
              System.Drawing.Imaging.PixelFormat.Format32bppPArgb
            );

            BitmapData data = bmp.LockBits
            (
                new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size),
                ImageLockMode.WriteOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppPArgb
            );

            source.CopyPixels
            (
              Int32Rect.Empty,
              data.Scan0,
              data.Height * data.Stride,
              data.Stride
            );

            bmp.UnlockBits(data);

            return bmp;
        }
        /// <summary>
        /// 
        /// </summary>
        public static Bitmap Combine_Two_Bitmap(Bitmap one, int onew, int oneh, Bitmap two, int twow, int twoh)
        {
            Bitmap second = new Bitmap(twow, twoh);
            second = (Bitmap)two.Clone();
            Graphics newImage = Graphics.FromImage(one);
            newImage.DrawImage(second, 0, 0, onew, oneh);
            return one;
        }
    }
}
