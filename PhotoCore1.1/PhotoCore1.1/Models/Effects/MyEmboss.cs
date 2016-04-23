using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.Drawing;
using System.Linq;

namespace PhotoCore1._1.Models.Effects
{
    public class MyEmboss
    {
        public MyEmboss()
        {
        }
        /// <summary>
        /// Applying Emboss filter to the bitmap
        /// </summary>
        public void ApplyFilter(Bitmap b)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-1);
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 0;
            m.Pixel = 4;
            m.Offset = 127;
            b = MatrixFunction.Conv3X3(b, m);
        }
    }
}
