using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoCore1._1.StaticFunctionClasses
{
    public static class ImageConverterFormat
    {
        /// <summary>
        /// Convert Bitmap to BitmapImage
        /// </summary>
        /// <param name="bmp1"></param>
        /// <returns></returns>
        public static BitmapImage BitmapToBitmapImage(Bitmap bmp1)
        {
            MemoryStream ms = new MemoryStream();
            bmp1.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();
            return bi;
        }

        /// <summary>
        /// Convert BitmapImage to Bitmap
        /// </summary>
        /// <param name="bitmapImage"></param>
        /// <returns></returns>
        public static Bitmap BitmapImageToBitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);
                return new Bitmap(bitmap);
            }
        }
        /// <summary>
        /// Convert Bitmap List to BitmapImage List
        /// </summary>
        /// <param name="bitmaps"></param>
        /// <returns></returns>
        public static List<BitmapImage> BitmapListToBitmapImageList(List<Bitmap> bitmaps)
        {
            List<BitmapImage> bitmapsimage = new List<BitmapImage>();
            for (int i = 0; i < bitmaps.Count; i++)
            {
                bitmapsimage.Insert(i, BitmapToBitmapImage(bitmaps[i]));
            }
            return bitmapsimage;
        }

        /// <summary>
        /// Get bitmap from source
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Bitmap GetBitmapFromSource(BitmapSource source)
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
        /// Convert UIElement to BitmapSource
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static BitmapSource ConvertToBitmapSource(UIElement element)
        {
            var target = new RenderTargetBitmap((int)(element.RenderSize.Width), (int)(element.RenderSize.Height), 96, 96, PixelFormats.Pbgra32);
            var brush = new VisualBrush(element);

            var visual = new DrawingVisual();
            var drawingContext = visual.RenderOpen();


            drawingContext.DrawRectangle(brush, null, new Rect(new System.Windows.Point(0, 0),
                new System.Windows.Point(element.RenderSize.Width, element.RenderSize.Height)));

            drawingContext.Close();

            target.Render(visual);

            return target;
        }
    }
}
