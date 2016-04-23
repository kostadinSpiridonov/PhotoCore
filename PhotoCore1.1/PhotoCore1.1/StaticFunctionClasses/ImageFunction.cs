using PhotoCore1._1.Models;
using PhotoCore1._1.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoCore1._1.StaticFunctionClasses
{
    public static class ImageFunction
    {
        /// <summary>
        /// Open Image 
        /// </summary>
        /// <returns></returns>
        public static Bitmap OpenImage()
        {
            Bitmap temporary = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.png";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream str = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                temporary = (Bitmap)Bitmap.FromStream(str, true, true);
                temporary.SetPixel(0, 0, temporary.GetPixel(0, 0));
                str.Flush();
                str.Close();
                VisibilityProperties.Instance.NewListBorder = false;
                VisibilityProperties.Instance.NotifyProperties();
                Images.Instance.BitmapPath = ofd.FileName.Trim();
                Images.Instance.ChangeSum--;
            }
            else
            {
                temporary = (Bitmap)Images.Instance.CurrentBitmap;
            }
            return temporary;
        }
        /// <summary>
        /// Set new image
        /// </summary>
        /// <returns></returns>
        public static Bitmap NewImage()
        {
            Bitmap temporary = null;
            FileStream str = new FileStream("../../Resources/DefaultPic.jpg", FileMode.Open, FileAccess.Read, FileShare.None);
            temporary = (Bitmap)Bitmap.FromStream(str, true, true);
            temporary.SetPixel(0, 0, temporary.GetPixel(0, 0));
            str.Flush();
            str.Close();
            return temporary;
        }
        /// <summary>
        /// Question about saving
        /// </summary>
        /// <returns></returns>
        public static Bitmap OpenNewQuestion()
           {
            Bitmap a=(Bitmap)Images.Instance.CurrentBitmap.Clone();
                Images.Instance.ChangeSum--;
                if (Images.Instance.ChangeSum > 0)
                {
                    switch (System.Windows.MessageBox.Show(Language.CurrentLanguage[30].ToString(), "PhotoCore", MessageBoxButton.YesNo))
                    {

                            case MessageBoxResult.No:
                                {
                                    Images.Instance.ChangeSum = 0;
                                    a = (Bitmap)NewImage().Clone();
                                    break;
                                }
                        case MessageBoxResult.Yes:
                            {
                                if (File.Exists(Images.Instance.BitmapPath))
                                {
                                    ImageFunction.SaveCurrentImage(Images.Instance.CurrentBitmap, Images.Instance.BitmapPath);
                                    a = (Bitmap)NewImage().Clone();
                                    break;
                                }
                                else
                                {
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
                                        a = (Bitmap)NewImage().Clone();
                                        break;
                                    }
                                    else
                                    {
                                        Images.Instance.ChangeSum++;
                                        a = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                                        break;

                                    }
                                }
                            }
                    }
                }
            else
            {
                a = (Bitmap)NewImage().Clone();
            }
                return a;
           }
        /// <summary>
        /// New question about saving
        /// </summary>
        /// <returns></returns>
        public static Bitmap NewQuestion()
        {
            Bitmap a=(Bitmap)Images.Instance.CurrentBitmap.Clone();
                Images.Instance.ChangeSum--;
                if (Images.Instance.ChangeSum > 0)
                {
                    switch (System.Windows.MessageBox.Show(Language.CurrentLanguage[30].ToString(), "PhotoCore", MessageBoxButton.YesNoCancel))
                    {

                            case MessageBoxResult.No:
                                {
                                    Images.Instance.ChangeSum = 0;
                                    a = (Bitmap)NewImage().Clone();
                                    break;
                                }
                            case MessageBoxResult.Cancel:
                                {
                                    Images.Instance.ChangeSum++;
                                    a = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                                    break;
                                }
                        case MessageBoxResult.Yes:
                            {
                                if (File.Exists(Images.Instance.BitmapPath))
                                {
                                    ImageFunction.SaveCurrentImage(Images.Instance.CurrentBitmap, Images.Instance.BitmapPath);
                                    a = (Bitmap)NewImage().Clone();
                                    break;
                                }
                                else
                                {
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
                                        a = (Bitmap)NewImage().Clone();
                                        break;
                                    }
                                    else
                                    {
                                        Images.Instance.ChangeSum++;
                                        a = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                                        break;

                                    }
                                 }
                         }
                   }
               }
            else
            {
                a = (Bitmap)NewImage().Clone();
            }
                return a;
           }
      
        /// <summary>
        /// Save as bitmap
        /// </summary>
        /// <param name="bmp"></param>
        public static void SaveAsCurrentImage(Bitmap bmp)
        {
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
                        bmp.Save(s.FileName, ImageFormat.Jpeg);
                    }
                    else if (s.FileName.Contains(".png"))
                    {
                        bmp.Save(s.FileName, ImageFormat.Png);
                    }
                    else if (s.FileName.Contains(".bmp"))
                    {
                        bmp.Save(s.FileName, ImageFormat.Bmp);
                    }
                }
                catch
                {
                }
            }
        }
    
        /// <summary>
        /// Save  bitmap
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="BmpPath"></param>
        public static void SaveCurrentImage(Bitmap bmp, string BmpPath)
        {
            FileStream str = new FileStream(BmpPath, FileMode.Open, FileAccess.Write, FileShare.None);
            bmp.Save(str, ImageFormat.Jpeg);
            str.Flush();
            str.Close();
        }

        private static System.Drawing.Rectangle selectedArea1;      
        /// <summary>
        /// Cert Selected area points
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="SelectPointUp"></param>
        /// <param name="SelectPoint"></param>
        public static void CopySelectedAreaToBitmap(int width, int height, System.Windows.Point SelectPointUp, System.Windows.Point SelectPoint)
        {
            if (SelectPoint.X < SelectPointUp.X && SelectPoint.Y < SelectPointUp.Y)
            {
                selectedArea1 = new System.Drawing.Rectangle((int)SelectPoint.X, (int)SelectPoint.Y, width, height);
                SelectedPoints.selectPointForEfX = (int)SelectPoint.X;
                SelectedPoints.selectPointForEfY = (int)SelectPoint.Y;
            }
            else
                if (SelectPoint.X > SelectPointUp.X && SelectPoint.Y > SelectPointUp.Y)
                {
                    selectedArea1 = new System.Drawing.Rectangle((int)SelectPointUp.X, (int)SelectPointUp.Y, width, height);
                    SelectedPoints.selectPointForEfX = (int)SelectPointUp.X;
                    SelectedPoints.selectPointForEfY = (int)SelectPointUp.Y;
                }
                else
                    if (SelectPoint.X > SelectPointUp.X && SelectPoint.Y < SelectPointUp.Y)
                    {
                        selectedArea1 = new System.Drawing.Rectangle((int)SelectPoint.X - width, (int)SelectPoint.Y, width, height);
                        SelectedPoints.selectPointForEfX = (int)SelectPoint.X - width;
                        SelectedPoints.selectPointForEfY = (int)SelectPoint.Y;
                    }
                    else
                        if (SelectPoint.X < SelectPointUp.X && SelectPoint.Y > SelectPointUp.Y)
                        {
                            selectedArea1 = new System.Drawing.Rectangle((int)SelectPoint.X, (int)SelectPoint.Y - height, width, height);
                            SelectedPoints.selectPointForEfX = (int)SelectPoint.X;
                            SelectedPoints.selectPointForEfY = (int)SelectPoint.Y - height;
                        }
            Images.Instance.SelectedBitmap = null;
            try
            {
                Images.Instance.SelectedBitmap = Images.Instance.CurrentBitmap.Clone(selectedArea1, Images.Instance.CurrentBitmap.PixelFormat);
            }
            catch { }

        }
       
        /// <summary>
        /// Flip and Rotate bitmap
        /// </summary>
        /// <param name="r"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Bitmap RotateFlip(RotateFlipType r,Bitmap a)
        {
            Bitmap temp = (Bitmap)a.Clone();
            temp.RotateFlip(r);
            return temp;
        }

        /// <summary>
        /// Get clipboard image
        /// </summary>
        /// <returns></returns>
        public static Bitmap SetClipboardImageToBitmap()
        {
            return (Bitmap)System.Windows.Forms.Clipboard.GetImage().Clone();
        }

        /// <summary>
        /// Clear selecred bitmap
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap Clear_Selected_Area(Bitmap bmp)
        {
            Bitmap temp = (Bitmap)bmp.Clone();
            System.Drawing.Rectangle clear = new System.Drawing.Rectangle();
            clear.Width = Images.Instance.SelectedBitmap.Width;
            clear.Height = Images.Instance.SelectedBitmap.Height;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            System.Drawing.Graphics formGraphics = Graphics.FromImage(temp);
            if (SelectedPoints.PointDown.X < SelectedPoints.PointUp.X && SelectedPoints.PointDown.Y < SelectedPoints.PointUp.Y)
            {
                formGraphics.FillRectangle(myBrush, (int)SelectedPoints.PointDown.X, (int)SelectedPoints.PointDown.Y, Images.Instance.SelectedBitmap.Width, Images.Instance.SelectedBitmap.Height);
            }
            else
                if (SelectedPoints.PointDown.X > SelectedPoints.PointUp.X && SelectedPoints.PointDown.Y > SelectedPoints.PointUp.Y)
                {
                    formGraphics.FillRectangle(myBrush, (int)SelectedPoints.PointUp.X, (int)SelectedPoints.PointUp.Y, Images.Instance.SelectedBitmap.Width, Images.Instance.SelectedBitmap.Height);
                }
                else
                    if (SelectedPoints.PointDown.X > SelectedPoints.PointUp.X && SelectedPoints.PointDown.Y < SelectedPoints.PointUp.Y)
                    {
                        formGraphics.FillRectangle(myBrush, (int)SelectedPoints.PointDown.X - clear.Width, (int)SelectedPoints.PointDown.Y, Images.Instance.SelectedBitmap.Width, Images.Instance.SelectedBitmap.Height);
                    }
                    else
                        if (SelectedPoints.PointDown.X < SelectedPoints.PointUp.X && SelectedPoints.PointDown.Y > SelectedPoints.PointUp.Y)
                        {
                            formGraphics.FillRectangle(myBrush, (int)SelectedPoints.PointDown.X, (int)SelectedPoints.PointDown.Y - clear.Height, Images.Instance.SelectedBitmap.Width, Images.Instance.SelectedBitmap.Height);
                        }
            myBrush.Dispose();
            formGraphics.Dispose();
            return temp;
        }


        /// <summary>
        /// Resize bitmap
        /// </summary>
        /// <param name="currentBitmap"></param>
        /// <param name="newWidth"></param>
        /// <param name="newHeight"></param>
        /// <returns></returns>
        public static Bitmap ResizeBitmap(Bitmap currentBitmap, int newWidth, int newHeight)
        {
            System.Drawing.Size newSize;
            try
            {
                newSize = new System.Drawing.Size(currentBitmap.Width * newWidth / 100, currentBitmap.Height * newHeight / 100);
                Bitmap newImage = new Bitmap((System.Drawing.Image)currentBitmap, newSize);
                return newImage;
            }
            catch
            {
                return currentBitmap;
            }
        }

        /// <summary>
        /// Skew bitmap
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="rightShift"></param>
        /// <param name="upShift"></param>
        /// <returns></returns>
        public static Bitmap Skew(Bitmap bmp, int rightShift, int upShift)
        {
            Bitmap result = new Bitmap(bmp.Width + Math.Abs(rightShift), bmp.Height + Math.Abs(upShift));
            Graphics g = Graphics.FromImage(result);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            System.Drawing.Point[] points = new System.Drawing.Point[3];
            int horShiftCorrections = 0;
            int verShiftCorrections = 0;
            if (rightShift < 0)
            {
                horShiftCorrections = rightShift * (-1);
            }
            if (upShift < 0)
            {
                verShiftCorrections = upShift * (-1);
            }
            points[0] = new System.Drawing.Point(horShiftCorrections + rightShift, verShiftCorrections);
            points[1] = new System.Drawing.Point(horShiftCorrections + rightShift + bmp.Width, verShiftCorrections + upShift);
            points[2] = new System.Drawing.Point(horShiftCorrections, verShiftCorrections + bmp.Height);

            try
            {
                g.DrawImage(bmp, points);
            }
            catch (Exception)
            {
            }
            return result;
        }

        /// <summary>
        /// Create stack from two stacks and one bitmap
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static List<Bitmap> CreateListFromTwoStackAndBitmap(Stack<Bitmap> first,Stack<Bitmap> second,Bitmap bmp)
        {
            List<Bitmap> last = new List<Bitmap>();
            List<Bitmap> firstlist = new List<Bitmap>(first);
            firstlist.Reverse();
            List<Bitmap> secondlist = new List<Bitmap>(second);
            secondlist.Reverse();
            last.AddRange(firstlist);
            last.Add(bmp);
            last.AddRange(secondlist);
            return last;
        }

        /// <summary>
        /// Calculate star point from rectangle
        /// </summary>
        /// <param name="up"></param>
        /// <param name="startP"></param>
        /// <returns></returns>
        public static System.Windows.Point StartPointCalculate(System.Windows.Point up, System.Windows.Point startP)
        {
            System.Windows.Point last = new System.Windows.Point();
            if (startP.X < up.X && startP.Y < up.Y)
            {
                last.X = (int)startP.X;
                last.Y = (int)startP.Y;
            }
            else
                if (startP.X > up.X && startP.Y > up.Y)
                {
                    last.X = up.X;
                    last.Y = up.Y;

                }
                else
                    if (startP.X > up.X && startP.Y < up.Y)
                    {
                        last.X = (int)up.X;
                        last.Y = (int)startP.Y;

                    }
                    else
                        if (startP.X < up.X && startP.Y > up.Y)
                        {
                            last.X = (int)startP.X;
                            last.Y = (int)up.Y;

                        }
            return last;
        }

        /// <summary>
        /// Captuer part of screen
        /// </summary>
        /// <param name="captureWidth"></param>
        /// <param name="captureHeight"></param>
        /// <param name="startCapturePoint"></param>
        /// <returns></returns>
        public static Bitmap Capture(int captureWidth, int captureHeight, System.Windows.Point startCapturePoint)
        {
            Bitmap bmp;
            var capture = new System.Drawing.Bitmap(captureWidth, captureHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            var g = System.Drawing.Graphics.FromImage(capture);
            g.CopyFromScreen((int)startCapturePoint.X, (int)startCapturePoint.Y, 0, 0, new System.Drawing.Size(captureWidth, captureHeight));
            g.Dispose();
            bmp = (Bitmap)capture.Clone();
            return bmp;
        }

        /// <summary>
        /// Make rounded corners to bitmap
        /// </summary>
        /// <param name="a"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static Bitmap MakeRoundedCorners(Bitmap a, Int32 radius)
        {
            Bitmap bmp = (Bitmap)a.Clone();
            Graphics g = Graphics.FromImage(bmp);
            System.Drawing.Brush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);

            for (int i = 0; i < 4; i++)
            {
                System.Windows.Point[] cornerUpLeft = new System.Windows.Point[3];

                cornerUpLeft[0].X = 0;
                cornerUpLeft[0].Y = 0;

                cornerUpLeft[1].X = radius;
                cornerUpLeft[1].Y = 0;

                cornerUpLeft[2].X = 0;
                cornerUpLeft[2].Y = radius;

                System.Drawing.Drawing2D.GraphicsPath pathCornerUpLeft =
                    new System.Drawing.Drawing2D.GraphicsPath();

                pathCornerUpLeft.AddArc((int)cornerUpLeft[0].X, (int)cornerUpLeft[0].Y,
                    radius, radius, 180, 90);
                pathCornerUpLeft.AddLine((int)cornerUpLeft[0].X, (int)cornerUpLeft[0].Y,
                    (int)cornerUpLeft[1].X, (int)cornerUpLeft[1].Y);
                pathCornerUpLeft.AddLine((int)cornerUpLeft[0].X, (int)cornerUpLeft[0].Y,
                    (int)cornerUpLeft[2].X, (int)cornerUpLeft[2].Y);

                g.FillPath(brush, pathCornerUpLeft);
                pathCornerUpLeft.Dispose();

                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            brush.Dispose();
            g.Dispose();

            System.Drawing.Color backColor = bmp.GetPixel(0, 0);

            bmp.MakeTransparent(backColor);

            return bmp;
        }

        /// <summary>
        /// Draw frame to bitmap
        /// </summary>
        /// <param name="image"></param>
        /// <param name="frame"></param>
        /// <returns></returns>
        public static Bitmap DrawFrameToBitmap(Bitmap image, Bitmap frame)
        {
            using (Graphics g = Graphics.FromImage((System.Drawing.Image)image))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(frame, 0, 0, image.Width, image.Height);
            }
            return image;
        }
    }
}
