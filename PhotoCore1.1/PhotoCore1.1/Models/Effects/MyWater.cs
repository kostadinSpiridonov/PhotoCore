using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.Drawing;
using System.Linq;

namespace PhotoCore1._1.Models.Effects
{
    class MyWater
    {
        public MyWater()
        {
        }
        /// <summary>
        /// Apply water effect to bitmap
        /// </summary>
        public void ApplyFilter(Bitmap b, short nWave)
        {
            int nWidth = b.Width;
            int nHeight = b.Height;

            Point[,] pt = new Point[nWidth, nHeight];

            Point mid = new Point();
            mid.X = nWidth / 2;
            mid.Y = nHeight / 2;

            double newX, newY;
            double xo, yo;

            for (int x = 0; x < nWidth; ++x)
                for (int y = 0; y < nHeight; ++y)
                {
                    xo = ((double)nWave * Math.Sin(2.0 * 3.1415 * (float)y / 128.0));
                    yo = ((double)nWave * Math.Cos(2.0 * 3.1415 * (float)x / 128.0));

                    newX = (x + xo);
                    newY = (y + yo);

                    if (newX > 0 && newX < nWidth)
                    {
                        pt[x, y].X = (int)newX;
                    }
                    else
                    {
                        pt[x, y].X = 0;
                    }

                    if (newY > 0 && newY < nHeight)
                    {
                        pt[x, y].Y = (int)newY;
                    }
                    else
                    {
                        pt[x, y].Y = 0;
                    }
                }

            MatrixFunction.OffsetFilterAbs(b, pt);
        }
    }
}
