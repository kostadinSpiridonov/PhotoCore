using System;
using System.Drawing;
using System.Linq;

namespace PhotoCore1._1.Models.Effects
{
    public class MyGrayScale
    {
        public MyGrayScale()
        { }
        /// <summary>
        /// Applying grayscale filter to bitmap
        /// </summary>
        public void SetGrayscale(Bitmap bmap)
        {
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);

                    bmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
        }
    }
}
