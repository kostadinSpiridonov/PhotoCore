using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCore1._1.StaticFunctionClasses
{
    static class MatrixFunction
    {
        /// <summary>
        /// Convert the bitmap to 3X3
        /// </summary>
        public static Bitmap Conv3X3(Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors
            if (0 == m.Factor)
                return b;

            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new System.Drawing.Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new System.Drawing.Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            IntPtr scan0 = bmData.Scan0;
            var srcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)scan0;
                byte* pSrc = (byte*)(void*)srcScan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((pSrc[2] * m.TopLeft) + (pSrc[5] * m.TopMid) + (pSrc[8] * m.TopRight) +
                                    (pSrc[2 + stride] * m.MidLeft) + (pSrc[5 + stride] * m.Pixel) + (pSrc[8 + stride] * m.MidRight) +
                                    (pSrc[2 + stride2] * m.BottomLeft) + (pSrc[5 + stride2] * m.BottomMid) + (pSrc[8 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0)
                            nPixel = 0;
                        if (nPixel > 255)
                            nPixel = 255;

                        p[5 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[1] * m.TopLeft) + (pSrc[4] * m.TopMid) + (pSrc[7] * m.TopRight) +
                                    (pSrc[1 + stride] * m.MidLeft) + (pSrc[4 + stride] * m.Pixel) + (pSrc[7 + stride] * m.MidRight) +
                                    (pSrc[1 + stride2] * m.BottomLeft) + (pSrc[4 + stride2] * m.BottomMid) + (pSrc[7 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0)
                            nPixel = 0;
                        if (nPixel > 255)
                            nPixel = 255;

                        p[4 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopMid) + (pSrc[6] * m.TopRight) +
                                    (pSrc[0 + stride] * m.MidLeft) + (pSrc[3 + stride] * m.Pixel) + (pSrc[6 + stride] * m.MidRight) +
                                    (pSrc[0 + stride2] * m.BottomLeft) + (pSrc[3 + stride2] * m.BottomMid) + (pSrc[6 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0)
                            nPixel = 0;
                        if (nPixel > 255)
                            nPixel = 255;

                        p[3 + stride] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return b;
        }
        /// <summary>
        /// Off set the filter in bitmap
        /// </summary>
        public static bool OffsetFilter(Bitmap b, System.Drawing.Point[,] offset)
        {
            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new System.Drawing.Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new System.Drawing.Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            int scanline = bmData.Stride;

            System.IntPtr scan0 = bmData.Scan0;
            System.IntPtr srcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)scan0;
                byte* pSrc = (byte*)(void*)srcScan0;

                int nOffset = bmData.Stride - b.Width * 3;
                int nWidth = b.Width;
                int nHeight = b.Height;

                int xOffset, yOffset;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        xOffset = offset[x, y].X;
                        yOffset = offset[x, y].Y;

                        if (y + yOffset >= 0 && y + yOffset < nHeight && x + xOffset >= 0 && x + xOffset < nWidth)
                        {
                            p[0] = pSrc[((y + yOffset) * scanline) + ((x + xOffset) * 3)];
                            p[1] = pSrc[((y + yOffset) * scanline) + ((x + xOffset) * 3) + 1];
                            p[2] = pSrc[((y + yOffset) * scanline) + ((x + xOffset) * 3) + 2];
                        }

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }
        /// <summary>
        /// Abs offset the filter in bitmap
        /// </summary>
        public static bool OffsetFilterAbs(Bitmap b, System.Drawing.Point[,] offset)
        {
            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new System.Drawing.Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new System.Drawing.Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            int scanline = bmData.Stride;

            System.IntPtr scan0 = bmData.Scan0;
            System.IntPtr srcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)scan0;
                byte* pSrc = (byte*)(void*)srcScan0;

                int nOffset = bmData.Stride - b.Width * 3;
                int nWidth = b.Width;
                int nHeight = b.Height;

                int xOffset, yOffset;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        xOffset = offset[x, y].X;
                        yOffset = offset[x, y].Y;

                        if (yOffset >= 0 && yOffset < nHeight && xOffset >= 0 && xOffset < nWidth)
                        {
                            p[0] = pSrc[(yOffset * scanline) + (xOffset * 3)];
                            p[1] = pSrc[(yOffset * scanline) + (xOffset * 3) + 1];
                            p[2] = pSrc[(yOffset * scanline) + (xOffset * 3) + 2];
                        }

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }
        /// <summary>
        /// Apply color matrix on bitmap
        /// </summary>
        public static Bitmap ApplyColorMatrix(Bitmap sourceImage, ColorMatrix colorMatrix)
        {
            Bitmap bmp32BppSource = (Bitmap)sourceImage.Clone();
            Bitmap bmp32BppDest = new Bitmap(bmp32BppSource.Width, bmp32BppSource.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(bmp32BppDest))
            {
                ImageAttributes bmpAttributes = new ImageAttributes();
                bmpAttributes.SetColorMatrix(colorMatrix);

                graphics.DrawImage(bmp32BppSource, new System.Drawing.Rectangle(0, 0, bmp32BppSource.Width, bmp32BppSource.Height),
                    0, 0, bmp32BppSource.Width, bmp32BppSource.Height, GraphicsUnit.Pixel, bmpAttributes);
            }

            bmp32BppSource.Dispose();

            return bmp32BppDest;
        }
    }
}
