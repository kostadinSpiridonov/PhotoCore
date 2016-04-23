using System;
using System.Drawing;
using System.Linq;

namespace PhotoCore1._1.Models.Effects
{
    public static class MyGamma
    {
        /// <summary>
        /// Applying gamma filter to the bitmap
        /// </summary>
        public static Bitmap ApplyFilter(Bitmap p, double red, double green, double blue)
        {
            Bitmap temp = p;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            byte[] redGamma = CreateGammaArray(red);
            byte[] greenGamma = CreateGammaArray(green);
            byte[] blueGamma = CreateGammaArray(blue);
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    bmap.SetPixel(i, j, Color.FromArgb(redGamma[c.R],
                        greenGamma[c.G], blueGamma[c.B]));
                }
            }
            p = (Bitmap)bmap.Clone();
            return p;
        }

        /// <summary>
        /// Create gamma array which help to applying the gamma fillter
        /// </summary>
        private static byte[] CreateGammaArray(double color)
        {
            byte[] gammaArray = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                gammaArray[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / color)) + 0.5));
            }
            return gammaArray;
        }
    }
}
