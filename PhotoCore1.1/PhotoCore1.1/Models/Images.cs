using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Media.Imaging;
using PhotoCore1._1.StaticFunctionClasses;
using System.ComponentModel;
namespace PhotoCore1._1.Models
{
    public class Images:INotifyPropertyChanged
    {
        public int UndoBr = 0;
        int start = 0;
        private static readonly Images instance = new Images();
        public Images() { }
        private static Bitmap currentBitmap=(Bitmap)ImageFunction.NewImage().Clone();
        private static Bitmap selectedBitmap;
        private static BitmapImage currentBitmapImage=ImageConverterFormat.BitmapToBitmapImage(ImageFunction.NewImage()).Clone();
        private static BitmapImage pasteBitmapImage;
        private static Bitmap pasteBitmap;
        private static Bitmap originalbitmap=(Bitmap)ImageFunction.NewImage().Clone();
     
        public static Images Instance
         {
             get
             {
                 return instance;
             }
         }
     
        public Bitmap CurrentBitmap
        {
            get
            {
                return currentBitmap;
            }
            set
            {
                if (UndoBr == UndoRedoModel.Instance.UndoStack.Count&&start>0)
                {
                    UndoRedoModel.Instance.UndoStack.Push(currentBitmap);
                    UndoRedoModel.Instance.RedoStack = new Stack<Bitmap>();
                    UndoBr++;
                    
                }
                start++;
                currentBitmap = value;
                if (currentBitmap != null)
                {
                    currentBitmapImage = ImageConverterFormat.BitmapToBitmapImage(currentBitmap);
                    ChangeSum++;
                }
            }
        }
       
        public  BitmapImage CurrentBitmapImage
        {
            get
            {
                return currentBitmapImage;       
            }
            set
            {
                currentBitmapImage = value;
                if (currentBitmapImage != null)
                {
                    currentBitmap = new Bitmap(ImageConverterFormat.BitmapImageToBitmap(currentBitmapImage));
                }
            }
        }
       
        public Bitmap SelectedBitmap
         {
             get
             {
                 return selectedBitmap;
             }
             set
             {
                 selectedBitmap = value;
             }
         }
        
        public Bitmap PasteBitmap
         {
             get
             {
                 return pasteBitmap;
             }
             set
             {
                 pasteBitmap = value;
                 if (pasteBitmap != null)
                 {
                     pasteBitmapImage = ImageConverterFormat.BitmapToBitmapImage(pasteBitmap);
                 }
             }
         }

        public Bitmap OriginalBitmap
        {
            get
            {
                return originalbitmap;
            }
            set
            {
                originalbitmap = value;
                NotifyPropertyChanged("OriginalBitmap");
            }
        }

        public BitmapImage PasteBitmapImage
         {
             get
             {
                 return pasteBitmapImage;
             }
             set
             {
                 pasteBitmapImage = value;
                 if (pasteBitmapImage != null)
                 {
                     pasteBitmap = new Bitmap(ImageConverterFormat.BitmapImageToBitmap(pasteBitmapImage));
                 }
             }
         }
  
        private FrameModel frame;
        public FrameModel Frame
        {
            get
            {
                return frame;
            }
            set
            {
                frame = value;
                NotifyPropertyChanged("Frame");
            }
        }

        public int ChangeSum = 0;
       
        private static string bitmappath;
        public string BitmapPath
        {
            get
            {
                return bitmappath;
            }
            set
            {
                bitmappath = value;
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
        public void NotifyImages()
        {
            NotifyPropertyChanged("CurrentBitmap");
            NotifyPropertyChanged("CurrentBitmapImage");
            NotifyPropertyChanged("PasteBitmap");
            NotifyPropertyChanged("PasteBitmapImage");
        }

        /// <summary>
        /// Draw frame to bitmap
        /// </summary>
        public void DrawFrame()
        {
            if (Images.Instance.Frame != null)
            {
                Bitmap f = ImageFunction.DrawFrameToBitmap(Images.Instance.CurrentBitmap, Images.Instance.Frame.Frame);
                Images.Instance.CurrentBitmap = (Bitmap)f.Clone();
                Images.Instance.NotifyImages();
                ChangeSum--;
            }
        }
    }
}
