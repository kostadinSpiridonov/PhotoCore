using PhotoCore1._1.Commands;
using PhotoCore1._1.Models;
using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;

namespace PhotoCore1._1.ViewModels
{
    public class InkCanvasViewModel:INotifyPropertyChanged
    {
        private System.Windows.Ink.StrokeCollection strokes = new System.Windows.Ink.StrokeCollection();
        public System.Windows.Ink.StrokeCollection Strokes
        {
            get
            {
                return this.strokes;
            }
            set
            {
                this.strokes = value;
            }
        }
    
        /// <summary>
        /// Draw the ink canvas to bitmap
        /// </summary>
        private ICommand draw;
        public ICommand Draw
        {
            get
            {
                if (this.draw == null)
                {
                    this.draw = new RelayCommand(this.DrawC);
                }
                return this.draw;
            }
        }
        private void DrawC(object obj)
        {
            if (Images.Instance.CurrentBitmap != null)
            {
                Drawing((int)Images.Instance.CurrentBitmap.Width, (int)Images.Instance.CurrentBitmap.Height, this.strokes, new System.Windows.Size(Images.Instance.CurrentBitmap.Width, Images.Instance.CurrentBitmap.Height));
                this.strokes.Clear();
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
        /// <summary>
        /// Drawing strokes
        /// </summary>
        /// <param name="canw"></param>
        /// <param name="canh"></param>
        /// <param name="strokes"></param>
        /// <param name="rendsize"></param>
        public void Drawing(int canw, int canh, StrokeCollection strokes, System.Windows.Size rendsize)
        {
            Bitmap cr = (Bitmap)Images.Instance.CurrentBitmap.Clone();
            Bitmap temp;
            Canvas a = new Canvas();
            a.Width = canw;
            a.Height = canh;
            a = DrawingImageFunctions.InkToXamlGeom(strokes, canw, canh);
            a.Background = System.Windows.Media.Brushes.Transparent;
            temp = (Bitmap)DrawingImageFunctions.Combine_Two_Bitmap(cr, Images.Instance.CurrentBitmap.Width, Images.Instance.CurrentBitmap.Height,
                DrawingImageFunctions.GetBitmap(DrawingImageFunctions.BuildImage(a, rendsize)), canw, canh).Clone(); ;
               Images.Instance.CurrentBitmap= (Bitmap)temp.Clone();
            Images.Instance.NotifyImages();
        }
    }
}
