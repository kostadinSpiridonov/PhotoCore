using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Media.Imaging;

namespace PhotoCore1._1.Models
{
    public class FrameModel:INotifyPropertyChanged
    {
        public FrameModel(Bitmap bmp)
        {
            this.Frame = bmp;
        }
      /// <summary>
      /// Frame bitmap
      /// </summary>
        private Bitmap frame;
        public Bitmap Frame
        {
            get
            {
                return frame;
            }
            set
            {
                frame = value;
                if (frame != null)
                {
                    FrameImage = ImageConverterFormat.BitmapToBitmapImage(frame).Clone();
                }
                NotifyPropertyChanged("Frame");
            }
        }
    /// <summary>
    /// Frame BitmapImage
    /// </summary>
        private BitmapImage frameimage;
        public BitmapImage FrameImage
        {
            get
            {
                return frameimage;
            }
            set
            {
                frameimage = value;
                NotifyPropertyChanged("FrameImage");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        } 
    }
}
