using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace PhotoCore1._1.Models.Effects
{
    class MyCartoon
    {
        public MyCartoon()
        {
        }
        /// <summary>
        /// Applying cartoon picture effect
        /// </summary>
        public void ApplyEffect(Bitmap sourceBitmap, int threshold)
        {
            BitmapData sourceData =
                sourceBitmap.LockBits(new System.Drawing.Rectangle(0, 0,
                    sourceBitmap.Width, sourceBitmap.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            int byteOffset = 0;
            int blueGradient, greenGradient, redGradient = 0;
            double blue = 0, green = 0, red = 0;

            bool exceedsThreshold = false;

            for (int offsetY = 1; offsetY <
                                  sourceBitmap.Height - 1; offsetY++)
            {
                for (int offsetX = 1; offsetX <
                                      sourceBitmap.Width - 1; offsetX++)
                {
                    byteOffset = offsetY * sourceData.Stride +
                                 offsetX * 4;

                    blueGradient =
                        Math.Abs(pixelBuffer[byteOffset - 4] -
                                 pixelBuffer[byteOffset + 4]);

                    blueGradient +=
                        Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                                 pixelBuffer[byteOffset + sourceData.Stride]);

                    byteOffset++;

                    greenGradient =
                        Math.Abs(pixelBuffer[byteOffset - 4] -
                                 pixelBuffer[byteOffset + 4]);

                    greenGradient +=
                        Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                                 pixelBuffer[byteOffset + sourceData.Stride]);

                    byteOffset++;

                    redGradient =
                        Math.Abs(pixelBuffer[byteOffset - 4] -
                                 pixelBuffer[byteOffset + 4]);

                    redGradient +=
                        Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                                 pixelBuffer[byteOffset + sourceData.Stride]);

                    if (blueGradient + greenGradient + redGradient > threshold)
                    {
                        exceedsThreshold = true;
                    }
                    else
                    {
                        byteOffset -= 2;

                        blueGradient = Math.Abs(pixelBuffer[byteOffset - 4] -
                                                pixelBuffer[byteOffset + 4]);
                        byteOffset++;

                        greenGradient = Math.Abs(pixelBuffer[byteOffset - 4] -
                                                 pixelBuffer[byteOffset + 4]);
                        byteOffset++;

                        redGradient = Math.Abs(pixelBuffer[byteOffset - 4] -
                                               pixelBuffer[byteOffset + 4]);

                        if (blueGradient + greenGradient + redGradient > threshold)
                        {
                            exceedsThreshold = true;
                        }
                        else
                        {
                            byteOffset -= 2;

                            blueGradient =
                                Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                                         pixelBuffer[byteOffset + sourceData.Stride]);

                            byteOffset++;

                            greenGradient =
                                Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                                         pixelBuffer[byteOffset + sourceData.Stride]);

                            byteOffset++;

                            redGradient =
                                Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                                         pixelBuffer[byteOffset + sourceData.Stride]);

                            if (blueGradient + greenGradient +
                                redGradient > threshold)
                            {
                                exceedsThreshold = true;
                            }
                            else
                            {
                                byteOffset -= 2;

                                blueGradient =
                                    Math.Abs(pixelBuffer[byteOffset - 4 - sourceData.Stride] -
                                             pixelBuffer[byteOffset + 4 + sourceData.Stride]);

                                blueGradient +=
                                    Math.Abs(pixelBuffer[byteOffset - sourceData.Stride + 4] -
                                             pixelBuffer[byteOffset + sourceData.Stride - 4]);

                                byteOffset++;

                                greenGradient =
                                    Math.Abs(pixelBuffer[byteOffset - 4 - sourceData.Stride] -
                                             pixelBuffer[byteOffset + 4 + sourceData.Stride]);

                                greenGradient +=
                                    Math.Abs(pixelBuffer[byteOffset - sourceData.Stride + 4] -
                                             pixelBuffer[byteOffset + sourceData.Stride - 4]);

                                byteOffset++;

                                redGradient =
                                    Math.Abs(pixelBuffer[byteOffset - 4 - sourceData.Stride] -
                                             pixelBuffer[byteOffset + 4 + sourceData.Stride]);

                                redGradient +=
                                    Math.Abs(pixelBuffer[byteOffset - sourceData.Stride + 4] -
                                             pixelBuffer[byteOffset + sourceData.Stride - 4]);

                                if (blueGradient + greenGradient + redGradient > threshold)
                                {
                                    exceedsThreshold = true;
                                }
                                else
                                {
                                    exceedsThreshold = false;
                                }
                            }
                        }
                    }

                    byteOffset -= 2;

                    if (exceedsThreshold)
                    {
                        blue = 0;
                        green = 0;
                        red = 0;
                    }
                    else
                    {
                        blue = pixelBuffer[byteOffset];
                        green = pixelBuffer[byteOffset + 1];
                        red = pixelBuffer[byteOffset + 2];
                    }

                    blue = (blue > 255 ? 255 : (blue < 0 ? 0 : blue));

                    green = (green > 255 ? 255 : (green < 0 ? 0 : green));

                    red = (red > 255 ? 255 : (red < 0 ? 0 : red));

                    resultBuffer[byteOffset] = (byte)blue;
                    resultBuffer[byteOffset + 1] = (byte)green;
                    resultBuffer[byteOffset + 2] = (byte)red;
                    resultBuffer[byteOffset + 3] = 255;
                }
            }


            BitmapData resultData =
                sourceBitmap.LockBits(new System.Drawing.Rectangle(0, 0,
                    sourceBitmap.Width, sourceBitmap.Height),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                resultBuffer.Length);

            sourceBitmap.UnlockBits(resultData);
        }

    }
}
