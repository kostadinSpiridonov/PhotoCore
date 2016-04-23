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
using System.Windows.Media;

namespace PhotoCore1._1.ViewModels
{
    public class SecondPageEffects:INotifyPropertyChanged
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
        /// Set jitter
        /// </summary>
        #region Jitter
        private readonly Jitter jitterFilter = new Jitter(5);
        private ICommand jitter;
        public ICommand Jitter
        {
            get
            {
                if (this.jitter == null)
                {
                    this.jitter = new RelayCommand(this.SetJitterC);
                }
                return this.jitter;
            }
        }
        private void SetJitterC(object obj)
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
                jitterFilter.ApplyInPlace(bmpselected);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);

            }
            else if(bmp!=null)
            {
                jitterFilter.ApplyInPlace(bmp);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Ser edge
        /// </summary>
        #region Edge
        private readonly Edges edgesFilter = new Edges();
        private ICommand edge;
        public ICommand Edge
        {
            get
            {
                if (this.edge == null)
                {
                    this.edge = new RelayCommand(this.SetEdgeC);
                }
                return this.edge;
            }
        }
        private void SetEdgeC(object obj)
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
                edgesFilter.ApplyInPlace(bmpselected);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);
            }
            else if(bmp!=null)
            {
                edgesFilter.ApplyInPlace(bmp);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Ser emboss
        /// </summary>
        #region Emboss
        private readonly MyEmboss embossFilter = new MyEmboss();
        private ICommand emboss;
        public ICommand Emboss
        {
            get
            {
                if (this.emboss == null)
                {
                    this.emboss = new RelayCommand(this.SetEmbossC);
                }
                return this.emboss;
            }
        }
        private void SetEmbossC(object obj)
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
                embossFilter.ApplyFilter(bmpselected);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);
            }
            else if(bmp!=null)
            {
                embossFilter.ApplyFilter(bmp);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion

        /// <summary>
        /// Set smooth
        /// </summary>
        #region Smooth
        private readonly MySmooth smoothFilter = new MySmooth();
        private ICommand smooth;
        public ICommand Smooth
        {
            get
            {
                if (this.smooth == null)
                {
                    this.smooth = new RelayCommand(this.SetSmoothC);
                }
                return this.smooth;
            }
        }
        private void SetSmoothC(object obj)
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
                smoothFilter.ApplyFilter(bmpselected,1);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);
            }
            else if(bmp!=null)
            {
                smoothFilter.ApplyFilter(bmp,1);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Set tint
        /// </summary>
        #region Tint
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

        private ICommand changetint;
        public ICommand ChangeTint
        {
            get
            {
                if (this.changetint == null)
                {
                    this.changetint = new RelayCommand(this.ChangeTintC);
                }
                return this.changetint;
            }
        }
        private void ChangeTintC(object obj)
        {
            Bitmap bmp = null;
            try
            {
                bmp = (Bitmap)this.Temporary.Clone();
            }
            catch { }
            if (bmp != null)
            {
                bmp = MyTint.ApplyEffect(bmp, red, green, blue);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            try
            {
                UndoRedoModel.Instance.UndoStack.Pop();
                Images.Instance.UndoBr--;
            }
            catch { }
        }

        private ICommand settint;
        public ICommand SetTint
        {
            get
            {
                if (this.settint == null)
                {
                    this.settint = new RelayCommand(this.SetTintC);
                }
                return this.settint;
            }
        }
        private void SetTintC(object obj)
        {
            UndoRedoModel.Instance.UndoStack.Push(this.Temporary);
            Images.Instance.UndoBr++;
            this.Temporary = Images.Instance.CurrentBitmap;
        }
        #endregion
        /// <summary>
        /// Set sepia
        /// </summary>
        #region Sepia
        private readonly Sepia sepiaFilter = new Sepia();
        private ICommand sepia;
        public ICommand Sepia
        {
            get
            {
                if (this.sepia == null)
                {
                    this.sepia = new RelayCommand(this.SetSepiaC);
                }
                return this.sepia;
            }
        }
        private void SetSepiaC(object obj)
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
                sepiaFilter.ApplyInPlace(bmpselected);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, SelectedPoints.selectPointForEfX, SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);
            }
            else if(bmp!=null)
            {
                sepiaFilter.ApplyInPlace(bmp);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Set sharpen
        /// </summary>
        #region Sharpen
        private readonly Sharpen sharpenFilter = new Sharpen();
        private ICommand sharpen;
        public ICommand Sharpen
        {
            get
            {
                if (this.sharpen == null)
                {
                    this.sharpen = new RelayCommand(this.SetSharpenC);
                }
                return this.sharpen;
            }
        }
        private void SetSharpenC(object obj)
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
                sharpenFilter.ApplyInPlace(bmpselected);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);
            }
            else if(bmp!=null)
            {
                sharpenFilter.ApplyInPlace(bmp);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Set change color
        /// </summary>
        #region ChangeColor
        private readonly ChangeColorPic chcEffect = new ChangeColorPic();
        private ICommand chosesecondcolor;
        public ICommand ChoseSecondColor
        {
            get
            {
                if (this.chosesecondcolor == null)
                {
                    this.chosesecondcolor = new RelayCommand(this.ChoseSC);
                }
                return this.chosesecondcolor;
            }
        }
        private void ChoseSC(object obj)
        {
            var dialog = new System.Windows.Forms.ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var dialogcolor = System.Drawing.Color.FromArgb(dialog.Color.A, dialog.Color.R, dialog.Color.G, dialog.Color.B);
                SecondColor = new SolidColorBrush(System.Windows.Media.Color.FromRgb(dialogcolor.R, dialogcolor.G, dialogcolor.B));
            }
        }

        private ICommand setSecondColor;
        public ICommand SetSecondColor
        {
            get
            {
                if (this.setSecondColor == null)
                {
                    this.setSecondColor = new RelayCommand(this.SetSecondColorC);
                }
                return this.setSecondColor;
            }
        }
        private void SetSecondColorC(object obj)
        {
            SolidColorBrush firs= obj as SolidColorBrush;
            System.Drawing.Color drfirstcol= System.Drawing.Color.FromArgb(firs.Color.A,firs.Color.R,firs.Color.G,firs.Color.B);
             System.Drawing.Color drsecondtcol= System.Drawing.Color.FromArgb(SecondColor.Color.A,SecondColor.Color.R,SecondColor.Color.G,SecondColor.Color.B);
            Bitmap bmp = (Bitmap)Images.Instance.CurrentBitmap.Clone();
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
                    bmpselected = chcEffect.ChangeColorOfPic(bmpselected, drfirstcol, drsecondtcol);
                    Graphics newImage = Graphics.FromImage(bmp);
                    newImage.DrawImage(bmpselected, (int)SelectedPoints.selectPointForEfX, (int)SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);
                }
            }
            else
            {
                bmp = chcEffect.ChangeColorOfPic(bmp, drfirstcol, drsecondtcol);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }

        private SolidColorBrush secondcolor = System.Windows.Media.Brushes.White;
        public SolidColorBrush SecondColor
        {
            get
            {
                return this.secondcolor;
            }
            set
            {
                this.secondcolor = value;
                NotifyPropertyChanged("SecondColor");
            }
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
            this.SecondColor = System.Windows.Media.Brushes.White;
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
