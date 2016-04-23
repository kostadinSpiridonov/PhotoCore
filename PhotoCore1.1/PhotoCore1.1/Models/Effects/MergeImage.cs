using System;
using System.Drawing;
using System.Linq;

namespace PhotoCore1._1.Models.Effects
{
    class MergeImage
    {

        public MergeImage()
        { }
        /// <summary>
        /// Merge two bitmap
        /// </summary>
        public Bitmap ApplyMerge(Bitmap currentBitmap,Bitmap mergeBitmap, int x, int y)
        {
            System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(x, y, mergeBitmap.Width, mergeBitmap.Height);
            System.Drawing.Imaging.PixelFormat format = mergeBitmap.PixelFormat;
            Bitmap cloneBitmap = currentBitmap.Clone(cloneRect, format);
            AForge.Imaging.Filters.Merge filter = new AForge.Imaging.Filters.Merge(cloneBitmap);
            Bitmap resultImage = filter.Apply(mergeBitmap);
            Graphics newImage = Graphics.FromImage(currentBitmap);
            newImage.DrawImage(resultImage, x, y, resultImage.Width, resultImage.Height);
            return currentBitmap;
        }
    }
}
