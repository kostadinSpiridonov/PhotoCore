using System;
using System.Drawing;
using System.Linq;

namespace PhotoCore1._1.Models.Effects
{
    public class ChangeColorPic
    {
        /// <summary>
        /// Change a color from picture with antoher color
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="firstColor"></param>
        /// <param name="secondColor"></param>
        /// <returns></returns>
        public Bitmap ChangeColorOfPic(Bitmap bmp,System.Drawing.Color firstColor,System.Drawing.Color secondColor)
        {
            Bitmap temp = bmp;
            Bitmap bmap = (Bitmap)temp.Clone();
            System.Drawing.Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    if (c.R > firstColor.R - 20 && c.R < firstColor.R + 20 && c.G > firstColor.G - 20 && c.G < firstColor.G + 20 && c.B > firstColor.B - 20 && c.B < firstColor.B + 20)
                    {
                        bmap.SetPixel(i, j, secondColor);
                    }
                }
            }
            bmp = (Bitmap)bmap.Clone();
            return bmp;
        }
    }
}
