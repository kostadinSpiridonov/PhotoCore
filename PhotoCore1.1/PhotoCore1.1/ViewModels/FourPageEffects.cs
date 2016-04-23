using AForge.Imaging.Filters;
using PhotoCore1._1.Commands;
using PhotoCore1._1.Models;
using PhotoCore1._1.Models.Effects;
using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Input;

namespace PhotoCore1._1.ViewModels
{
    public class FourPageEffects:INotifyPropertyChanged
    {
        private Bitmap temporary;
        public Bitmap Temporary
        {
            get
            {
                return this.temporary;
            }
            set
            {
                this.temporary = value;
                NotifyPropertyChanged("Temporary");
            }
        }
        private Nullable<bool> partarea = false;
        public Nullable<bool> PartArea
        {
            get
            {
                return this.partarea;
            }
            set
            {
                this.partarea = value;
                if (partarea == true)
                {
                    VisibilityProperties.Instance.SelectCanvasVisibility = true;
                    VisibilityProperties.Instance.NotifyProperties();
                }
                else
                {
                    VisibilityProperties.Instance.SelectCanvasVisibility = false;
                    VisibilityProperties.Instance.NotifyProperties();
                }
                NotifyPropertyChanged("PartArea");
            }
        }
    
        /// <summary>
        /// Set posterization
        /// </summary>
        #region Posterization
        private readonly SimplePosterization posterizationFilter = new SimplePosterization();
        private ICommand posterization;
        public ICommand Posterization
        {
            get
            {
                if (this.posterization == null)
                {
                    this.posterization = new RelayCommand(this.PosterizationC);
                }
                return this.posterization;
            }
        }
        private void PosterizationC(object obj)
        {
            Bitmap bmp = null;
            try
            {
                bmp = (Bitmap)Images.Instance.CurrentBitmap.Clone();
            }
            catch { }
            Bitmap bmpselected = null;
            try
            {
                bmpselected = (Bitmap)Images.Instance.SelectedBitmap.Clone();
            }
            catch { }
            if (partarea == true&&bmpselected!=null)
            {
                posterizationFilter.ApplyInPlace(bmpselected);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);

            }
            else if(bmp!=null)
            {
                posterizationFilter.ApplyInPlace(bmp);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion

        /// <summary>
        /// Set monochrome
        /// </summary>
        #region Monochrome
        private readonly MyMonochrome monochromeFilter = new MyMonochrome();
        private ICommand monochrome;
        public ICommand Monochrome
        {
            get
            {
                if (this.monochrome == null)
                {
                    this.monochrome = new RelayCommand(this.MonochromeC);
                }
                return this.monochrome;
            }
        }
        private void MonochromeC(object obj)
        {
            Bitmap bmp = null;
            try
            {
                bmp = (Bitmap)Images.Instance.CurrentBitmap.Clone();
            }
            catch { }
            Bitmap bmpselected = null; 
            try
            {
                bmpselected = (Bitmap)Images.Instance.SelectedBitmap.Clone();
            }
            catch { }
            if (partarea == true&&bmpselected!=null)
            {
                monochromeFilter.AppluEffect(bmpselected);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);

            }
            else if(bmp!=null)
            {
                monochromeFilter.AppluEffect(bmp);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Set wrap
        /// </summary>
        #region Warp
        private readonly MyWarp warpFilter = new MyWarp();
        private ICommand warp;
        public ICommand Warp
        {
            get
            {
                if (this.warp == null)
                {
                    this.warp = new RelayCommand(this.WarpC);
                }
                return this.warp;
            }
        }
        private void WarpC(object obj)
        {
            Bitmap bmp = null;
            try
            {
                bmp = (Bitmap)Images.Instance.CurrentBitmap.Clone();
            }
            catch { }

            Bitmap bmpselected = null; 
            try
            {
                bmpselected = (Bitmap)Images.Instance.SelectedBitmap.Clone();
            }
            catch { }
            if (partarea == true&&bmpselected!=null)
            {
                warpFilter.ApplyFilter(bmpselected,10);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);

            }
            else if(bmp!=null)
            {
                warpFilter.ApplyFilter(bmp,10);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Set solar
        /// </summary>
        #region Solar
        private int red = 0;
        public int Red
        {
            get
            {
                return this.red;
            }
            set
            {
                this.red = value;
                NotifyPropertyChanged("Red");
            }
        }

        private int green = 0;
        public int Green
        {
            get
            {
                return this.green;
            }
            set
            {
                this.green = value;
                NotifyPropertyChanged("Green");
            }
        }

        private int blue = 0;
        public int Blue
        {
            get
            {
                return this.blue;
            }
            set
            {
                this.blue = value;
                NotifyPropertyChanged("Blue");
            }
        }

        private ICommand changesolar;
        public ICommand ChangeSolar
        {
            get
            {
                if (this.changesolar == null)
                {
                    this.changesolar = new RelayCommand(this.ChangeColarC);
                }
                return this.changesolar;
            }
        }
        private void ChangeColarC(object obj)
        {
            try
            {
                Bitmap bmp = (Bitmap)this.Temporary.Clone();
                bmp = MySolarise.ApplyEffect(bmp, (byte)red, (byte)green, (byte)blue);
                Images.Instance.CurrentBitmap = bmp;
                Images.Instance.NotifyImages();
                UndoRedoModel.Instance.UndoStack.Pop();
                Images.Instance.UndoBr--;
            }
            catch { }
        }

        private ICommand setsolar;
        public ICommand SetSolar
        {
            get
            {
                if (this.setsolar == null)
                {
                    this.setsolar = new RelayCommand(this.SetSolarC);
                }
                return this.setsolar;
            }
        }
        private void SetSolarC(object obj)
        {
            UndoRedoModel.Instance.UndoStack.Push(this.Temporary);
            Images.Instance.UndoBr++;
            this.Temporary = Images.Instance.CurrentBitmap;
        }
        #endregion
        /// <summary>
        /// Set transperenty
        /// </summary>
        #region Transperenty
        private ICommand transperenty;
        public ICommand  Transperenty
        {
            get
            {
                if (this.transperenty == null)
                {
                    this.transperenty = new RelayCommand(this.TransperentyC);
                }
                return this.transperenty;
            }
        }
        private void TransperentyC(object obj)
        {
            Bitmap bmp = null;
            try
            {
                bmp = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                bmp = MyTransparenty.ApplyFilter(bmp);
                Images.Instance.CurrentBitmap = bmp;
                Images.Instance.NotifyImages();
            }
            catch
            { }
        }
        #endregion
        /// <summary>
        /// Back from panel
        /// </summary>
        private ICommand back;
        public ICommand Back
        {
            get
            {
                if (this.back == null)
                {
                    this.back = new RelayCommand(this.BackC);
                }
                return this.back;
            }
        }
        private void BackC(object obj)
        {
            if (Temporary != null)
            {
                if (UndoRedoModel.Instance.UndoStack.Count > 0)
                {
                    Images.Instance.CurrentBitmap = Temporary;
                }
            }
            Images.Instance.SelectedBitmap = null;
            Images.Instance.NotifyImages();
            try
            {
                UndoRedoModel.Instance.UndoStack.Pop();
                Images.Instance.UndoBr--;
            }
            catch { }
            VisibilityProperties.Instance.SelectCanvasVisibility = false;
            VisibilityProperties.Instance.SelectRectangleVisibility = false;
            VisibilityProperties.Instance.NotifyProperties();
            PartArea = false;
            this.Red = 0;
            this.Green = 0;
            this.Blue = 0;
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
