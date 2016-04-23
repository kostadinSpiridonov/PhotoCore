using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace PhotoCore1._1.Models.Effects
{
    static class MyTransparenty
    {
        /// <summary>
        /// Set transperenty to bitmap
        /// </summary>
        static public Bitmap ApplyFilter(Bitmap sourceImage, byte alphaComponent = 100)
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
            {
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 0.3f, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            });

            return MatrixFunction.ApplyColorMatrix(sourceImage, colorMatrix);
        }
    }
}
