using AForge.Imaging.Filters;
using PhotoCore1._1.Commands;
using PhotoCore1._1.Models;
using PhotoCore1._1.Models.Effects;
using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoCore1._1.ViewModels
{
    public  class FirstPageEffects:INotifyPropertyChanged
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
                if(partarea==true)
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
        /// Set brightness
        /// </summary>
        #region Brightness
        private int brightnessvalue = 0;
        public int BrightnessValue
        {
            get
            {
                return this.brightnessvalue;
            }
            set
            {
                this.brightnessvalue = value;
                NotifyPropertyChanged("BrightnessValue");
            }
        }


        private readonly BrightnessCorrection brFilter = new BrightnessCorrection();
        private ICommand changebrightness;
        public ICommand ChangeBrightness
        {
            get
            {
                if (this.changebrightness == null)
                {
                    this.changebrightness = new RelayCommand(this.ChangeBrightnessC);
                }
                return this.changebrightness;
            }
        }
        private void ChangeBrightnessC(object obj)
        {
            Bitmap bmp = (Bitmap)this.Temporary.Clone();
            brFilter.AdjustValue = BrightnessValue;
            brFilter.ApplyInPlace(bmp);
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            try
            {
                UndoRedoModel.Instance.UndoStack.Pop();
                Images.Instance.UndoBr--;
            }
            catch { }
        }

        private ICommand setbrightness;
        public ICommand SetBrightness
        {
            get
            {
                if (this.setbrightness == null)
                {
                    this.setbrightness = new RelayCommand(this.SetBrightnessC);
                }
                return this.setbrightness;
            }
        }
        private void SetBrightnessC(object obj)
        {
            UndoRedoModel.Instance.UndoStack.Push(this.Temporary);
            Images.Instance.UndoBr++;
            this.Temporary=Images.Instance.CurrentBitmap;
        }
        #endregion
        /// <summary>
        /// Set contrast
        /// </summary>
        #region Contrast
        private int contrastvalue = 0;
        public int ContrastValue
        {
            get
            {
                return this.contrastvalue;
            }
            set
            {
                this.contrastvalue = value;
                NotifyPropertyChanged("ContrastValue");
            }
        }


        private readonly ContrastCorrection contrastFilter = new ContrastCorrection();
        private ICommand changecontrast;
        public ICommand ChangeContrast
        {
            get
            {
                if (this.changecontrast == null)
                {
                    this.changecontrast = new RelayCommand(this.ChangeContrastC);
                }
                return this.changecontrast;
            }
        }
        private void ChangeContrastC(object obj)
        {

            Bitmap bmp = (Bitmap)this.Temporary.Clone();
            contrastFilter.Factor = (int)ContrastValue;
            contrastFilter.ApplyInPlace(bmp);
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            try
            {
                UndoRedoModel.Instance.UndoStack.Pop();
                Images.Instance.UndoBr--;
            }
            catch { }
        }

        private ICommand setcontrast;
        public ICommand SetContrast
        {
            get
            {
                if (this.setcontrast == null)
                {
                    this.setcontrast = new RelayCommand(this.SetContrastC);
                }
                return this.setcontrast;
            }
        }
        private void SetContrastC(object obj)
        {
            UndoRedoModel.Instance.UndoStack.Push(this.Temporary);
            Images.Instance.UndoBr++;
            this.Temporary = Images.Instance.CurrentBitmap;
        }
        #endregion
        /// <summary>
        /// Set gamma
        /// </summary>
        #region Gamma
        private int red = 1;
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

        private int green = 1;
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

        private int blue = 1;
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

        private ICommand changegamma;
        public ICommand ChangeGamma
        {
            get
            {
                if (this.changegamma == null)
                {
                    this.changegamma = new RelayCommand(this.ChangeGammaC);
                }
                return this.changegamma;
            }
        }
        private void ChangeGammaC(object obj)
        {
            Bitmap bmp = (Bitmap)this.Temporary.Clone();
            bmp = MyGamma.ApplyFilter(bmp, red, green, blue);
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            try
            {
                UndoRedoModel.Instance.UndoStack.Pop();
                Images.Instance.UndoBr--;
            }
            catch { }
        }

        private ICommand setgamma;
        public ICommand SetGamma
        {
            get
            {
                if (this.setgamma == null)
                {
                    this.setgamma = new RelayCommand(this.SetGammaC);
                }
                return this.setgamma;
            }
        }
        private void SetGammaC(object obj)
        {
            UndoRedoModel.Instance.UndoStack.Push(this.Temporary);
            Images.Instance.UndoBr++;
            this.Temporary = Images.Instance.CurrentBitmap;
        }
        #endregion
        /// <summary>
        /// Set median
        /// </summary>
        #region Median
        private bool blackandwhite = false; 
        public bool BlackAndWhite
        {
            get
            { 
                return this.blackandwhite;
            }
            set
            {
                this.blackandwhite = value;
                NotifyPropertyChanged("BlackAndWhite");
            }
        }
        private readonly MyMedian median = new MyMedian();

        private ICommand setmedian;
        public ICommand SetMedian
        {
            get
            {
                if (this.setmedian == null)
                {
                    this.setmedian = new RelayCommand(this.SetMedianC);
                }
                return this.setmedian;
            }
        }
        private void SetMedianC(object obj)
        {
            Bitmap bmp = null;
            try
            {
                bmp = (Bitmap)Images.Instance.CurrentBitmap.Clone();
            }
            catch{}
            Bitmap bmpselected = null; 
            try
            {
                bmpselected = (Bitmap)Images.Instance.SelectedBitmap.Clone();
            }
            catch { }
            if(partarea==true)
            {
                if (bmpselected != null)
                {
                    median.ApplyFilter(bmpselected, blackandwhite);
                    Graphics newImage = Graphics.FromImage(bmp);
                    newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);
                }
            }
            else
            {
                if (bmp != null)
                {
                    median.ApplyFilter(bmp, blackandwhite);
                }
            }
            Images.Instance.CurrentBitmap = bmp;
            this.Temporary = bmp;
            Images.Instance.NotifyImages();
        }
        #endregion
        /// <summary>
        /// Set grayscale
        /// </summary>
        #region GraySkale
        private readonly MyGrayScale mygrayscale = new MyGrayScale();
        private ICommand grayscale;
        public ICommand GraySkale
        {
            get
            {
                if (this.grayscale == null)
                {
                    this.grayscale = new RelayCommand(this.SetGraySkaleC);
                }
                return this.grayscale;
            }
        }
        private void SetGraySkaleC(object obj)
        {
            Bitmap bmp=null;
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
                mygrayscale.SetGrayscale(bmpselected);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);

            }
            else if(bmp!=null)
            {
                mygrayscale.SetGrayscale(bmp);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Set invert
        /// </summary>
        #region Invert
        private readonly Invert invertfilter = new Invert();
        private ICommand invert;
        public ICommand Invert
        {
            get
            {
                if (this.invert == null)
                {
                    this.invert = new RelayCommand(this.SetInvertC);
                }
                return this.invert;
            }
        }
        private void SetInvertC(object obj)
        {
            Bitmap bmp=null;
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
            if (partarea == true)
            {
                if (bmpselected != null)
                {
                    invertfilter.ApplyInPlace(bmpselected);
                    Graphics newImage = Graphics.FromImage(bmp);
                    newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);
                }
            }
            else
            {
                if (bmp != null)
                {
                    invertfilter.ApplyInPlace(bmp);
                }
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Set swirl
        /// </summary>
        #region Swrirl
        private readonly MySwirl myswirl = new MySwirl();
        private ICommand swirl;
        public ICommand Swirl
        {
            get
            {
                if (this.swirl == null)
                {
                    this.swirl = new RelayCommand(this.SetSwirlC);
                }
                return this.swirl;
            }
        }
        private void SetSwirlC(object obj)
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
                myswirl.ApplyFilter(bmpselected,.04);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);

            }
            else if(bmp!=null)
            {
                myswirl.ApplyFilter(bmp,.04);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Set spehere
        /// </summary>
        #region Sphere
        private readonly MySphere mysphere = new MySphere();
        private ICommand sphere;
        public ICommand Sphere
        {
            get
            {
                if (this.sphere == null)
                {
                    this.sphere = new RelayCommand(this.SetSphereC);
                }
                return this.sphere;
            }
        }
        private void SetSphereC(object obj)
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
                mysphere.ApplyFilter(bmpselected);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);

            }
            else if(bmp!=null)
            {
                mysphere.ApplyFilter(bmp);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Back button
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
            this.BrightnessValue = 0;
            this.ContrastValue = 0;
            this.Red = 1;
            this.Green = 1;
            this.Blue = 1;
            VisibilityProperties.Instance.SelectCanvasVisibility = false;
            VisibilityProperties.Instance.SelectRectangleVisibility = false;
            VisibilityProperties.Instance.NotifyProperties();
            PartArea = false;
            BlackAndWhite = false;
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
