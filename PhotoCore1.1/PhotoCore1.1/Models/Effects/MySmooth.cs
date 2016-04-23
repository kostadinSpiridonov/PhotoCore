using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.Drawing;
using System.Linq;

namespace PhotoCore1._1.Models.Effects
{
    public class MySmooth
    {
        public MySmooth()
        {
        }
        /// <summary>
        /// Apply smooth filter to bitmap
        /// </summary>
        public void ApplyFilter(Bitmap b, int nWeight)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.Factor = nWeight + 8;
            b = MatrixFunction.Conv3X3(b, m);
        }
    }
}
