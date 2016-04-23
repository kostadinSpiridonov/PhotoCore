using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.Drawing;
using System.Linq;

namespace PhotoCore1._1.Models.Effects
{
    class MySphere
    {
        public MySphere()
        {
        }
        /// <summary>
        /// Apply sphere effect to bitmap
        /// </summary>
        public void ApplyFilter(Bitmap b)
        {
            int nWidth = b.Width;
            int nHeight = b.Height;

            Point[,] fp = new Point[nWidth, nHeight];

            Point mid = new Point();
            mid.X = nWidth / 2;
            mid.Y = nHeight / 2;

            double theta, radius;
            double newX, newY;

            for (int x = 0; x < nWidth; ++x)
                for (int y = 0; y < nHeight; ++y)
                {
                    int trueX = x - mid.X;
                    int trueY = y - mid.Y;
                    theta = Math.Atan2((trueY), (trueX));

                    radius = Math.Sqrt(trueX * trueX + trueY * trueY);

                    double newRadius = radius * radius / (Math.Max(mid.X, mid.Y));

                    newX = mid.X + (newRadius * Math.Cos(theta));

                    if (newX > 0 && newX < nWidth)
                    {
                        fp[x, y].X = (int)newX;
                    }
                    else
                    {
                        fp[x, y].X = fp[x, y].Y = (int)0.0;
                    }

                    newY = mid.Y + (newRadius * Math.Sin(theta));

                    if (newY > 0 && newY < nHeight && newX > 0 && newX < nWidth)
                    {
                        fp[x, y].Y = (int)newY;
                    }
                    else
                    {
                        fp[x, y].X = fp[x, y].Y = (int)0.0;
                    }
                }

            MatrixFunction.OffsetFilterAbs(b, fp);
        }
    }
}
