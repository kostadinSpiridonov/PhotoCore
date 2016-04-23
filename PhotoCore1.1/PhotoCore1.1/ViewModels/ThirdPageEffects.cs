using AForge.Imaging.Filters;
using PhotoCore1._1.Commands;
using PhotoCore1._1.Models;
using PhotoCore1._1.Models.Effects;
using PhotoCore1._1.StaticFunctionClasses;
using PhotoCore1._1.View;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace PhotoCore1._1.ViewModels
{
    public class ThirdPageEffects:INotifyPropertyChanged
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
        /// Back to main panel
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
            PartArea = false;
            RaundedCornersValue = 1;
            MainImageView.Avtivity = 0;
            Images.Instance.NotifyImages();
            VisibilityProperties.Instance.PastePanelVisibility = false;
            VisibilityProperties.Instance.NotifyProperties();
            Images.Instance.NotifyImages();
           // HueValue = 0;
        }
        /// <summary>
        /// Ser grayscale
        /// </summary>
        #region GraySkale
        private readonly MyWater mywaterEffect = new MyWater();
        private ICommand mywater;
        public ICommand MyWater
        {
            get
            {
                if (this.mywater == null)
                {
                    this.mywater = new RelayCommand(this.SetWaterC);
                }
                return this.mywater;
            }
        }
        private void SetWaterC(object obj)
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
                mywaterEffect.ApplyFilter(bmpselected,5);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, SelectedPoints.selectPointForEfX, SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);

            }
            else if(bmp!=null)
            {
                mywaterEffect.ApplyFilter(bmp,5);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Set pixellete
        /// </summary>
        #region Pixellete
        private readonly Pixellate pixeletteFilter = new Pixellate();
        private ICommand pixelette;
        public ICommand Pixelette
        {
            get
            {
                if (this.pixelette == null)
                {
                    this.pixelette = new RelayCommand(this.SetPixelleteC);
                }
                return this.pixelette;
            }
        }
        private void SetPixelleteC(object obj)
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
                pixeletteFilter.ApplyInPlace(bmpselected);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, SelectedPoints.selectPointForEfX, SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);

            }
            else if(bmp!=null)
            {
                try
                {
                    pixeletteFilter.ApplyInPlace(bmp);
                }
                catch { }
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Set cartoon
        /// </summary>
        #region Cartoon
        private readonly MyCartoon cartoonFilter = new MyCartoon();
        private ICommand cartoon;
        public ICommand Cartoon
        {
            get
            {
                if (this.cartoon == null)
                {
                    this.cartoon = new RelayCommand(this.SetCartoonC);
                }
                return this.cartoon;
            }
        }
        private void SetCartoonC(object obj)
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
                cartoonFilter.ApplyEffect(bmpselected,200);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, SelectedPoints.selectPointForEfX, SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);

            }
            else if(bmp!=null)
            {
                cartoonFilter.ApplyEffect(bmp,200);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Set oil
        /// </summary>
        #region Oil
        private readonly OilPainting oilFilter = new OilPainting();
        private ICommand oil;
        public ICommand Oil
        {
            get
            {
                if (this.oil == null)
                {
                    this.oil = new RelayCommand(this.SetOilC);
                }
                return this.oil;
            }
        }
        private void SetOilC(object obj)
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
                oilFilter.ApplyInPlace(bmpselected);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, SelectedPoints.selectPointForEfX, SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);

            }
            else if(bmp!=null)
            {
                oilFilter.ApplyInPlace(bmp);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Set chnnel rotate
        /// </summary>
        #region ChannelRotate
        private readonly RotateChannels rotChanFilter = new RotateChannels();
        private ICommand channelrotate;
        public ICommand ChannelRotate
        {
            get
            {
                if (this.channelrotate == null)
                {
                    this.channelrotate = new RelayCommand(this.SetChannelRotateC);
                }
                return this.channelrotate;
            }
        }
        private void SetChannelRotateC(object obj)
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
                rotChanFilter.ApplyInPlace(bmpselected);
                Graphics newImage = Graphics.FromImage(bmp);
                newImage.DrawImage(bmpselected, SelectedPoints.selectPointForEfX, SelectedPoints.selectPointForEfY, bmpselected.Width, bmpselected.Height);

            }
            else if(bmp!=null)
            {
                rotChanFilter.ApplyInPlace(bmp);
            }
            Images.Instance.CurrentBitmap = bmp;
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
        }
        #endregion
        /// <summary>
        /// Set rounded corners
        /// </summary>
        #region RoundedCorners
        private int roundercornersvalue = 1;
        public int RaundedCornersValue
        {
            get
            {
                return this.roundercornersvalue;
            }
            set
            {
                this.roundercornersvalue = value;
                NotifyPropertyChanged("RaundedCornersValue");
            }
        }


        private readonly ContrastCorrection contrastFilter = new ContrastCorrection();
        private ICommand changeraundedcorners;
        public ICommand ChangeRoundedCorners
        {
            get
            {
                if (this.changeraundedcorners == null)
                {
                    this.changeraundedcorners = new RelayCommand(this.ChangeRoundedCornersC);
                }
                return this.changeraundedcorners;
            }
        }
        private void ChangeRoundedCornersC(object obj)
        {

            Bitmap bmp = null;
            try
            {
                bmp = (Bitmap)this.Temporary.Clone();
            }
            catch { }
            if (bmp != null)
            {
                bmp = ImageFunction.MakeRoundedCorners(bmp, roundercornersvalue);
                contrastFilter.ApplyInPlace(bmp);
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

        private ICommand setraundedcorners;
        public ICommand SetRaundedCorners
        {
            get
            {
                if (this.setraundedcorners == null)
                {
                    this.setraundedcorners = new RelayCommand(this.SetRaundedCornersC);
                }
                return this.setraundedcorners;
            }
        }
        private void SetRaundedCornersC(object obj)
        {
            UndoRedoModel.Instance.UndoStack.Push(this.Temporary);
            Images.Instance.UndoBr++;
            this.Temporary = Images.Instance.CurrentBitmap;
        }
        #endregion
        /// <summary>
        /// Set merge image
        /// </summary>
        #region MergeImage
        private readonly MergeImage mergeImage = new MergeImage();
        private ICommand openmergeimage;
        public ICommand OpenMergeImage
        {
            get
            {
                if (this.openmergeimage == null)
                {
                    this.openmergeimage = new RelayCommand(this.OpenMergeImageC);
                }
                return this.openmergeimage;
            }
        }
        private void OpenMergeImageC(object obj)
        {
            Bitmap k = null;
            MainImageView.Avtivity = 1; OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.png";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream str = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                    k = (Bitmap)Bitmap.FromStream(str, true, true);
                    str.Flush();
                    str.Close();
                }
                catch
                {
                }
                if(k.Height>=Images.Instance.CurrentBitmap.Height||
                    k.Width >= Images.Instance.CurrentBitmap.Width)
                {
                    System.Windows.MessageBox.Show("The picture is too large !!!\nChose new picture.");
                }
                else
                {
                    if(k!=null)
                    { 
                        Images.Instance.PasteBitmap = new Bitmap(k);
                        Images.Instance.NotifyImages();
                    }
                    VisibilityProperties.Instance.PastePanelVisibility = true;
                    VisibilityProperties.Instance.NotifyProperties();
                }
            }
        }

        private ICommand applymergeimage;
        public ICommand ApplyMergeImage
        {
            get
            {
                if (this.applymergeimage == null)
                {
                    this.applymergeimage = new RelayCommand(this.ApplyMergeImageC);
                }
                return this.applymergeimage;
            }
        }
        private void ApplyMergeImageC(object obj)
        {
            MainImageView.Avtivity = 0;
            Bitmap bmp = (Bitmap)Images.Instance.CurrentBitmap.Clone();
            if (Images.Instance.PasteBitmap != null)
            {
                bmp = mergeImage.ApplyMerge(bmp, Images.Instance.PasteBitmap, (int)SelectedPoints.MergePoint.X, (int)SelectedPoints.MergePoint.Y);
                Images.Instance.CurrentBitmap = bmp;
                Images.Instance.PasteBitmap = null;
                Images.Instance.NotifyImages();
            }
            VisibilityProperties.Instance.PastePanelVisibility = false;
            VisibilityProperties.Instance.NotifyProperties();
            Images.Instance.NotifyImages();
            this.Temporary = bmp;
           
        }

        private ICommand clearmergeimage;
        public ICommand ClearMergeImage
        {
            get
            {
                if (this.clearmergeimage == null)
                {
                    this.clearmergeimage = new RelayCommand(this.ClearApplyMergeC);
                }
                return this.clearmergeimage;
            }
        }
        private void ClearApplyMergeC(object obj)
        {
            MainImageView.Avtivity = 0;
            Images.Instance.PasteBitmap = null;
            Images.Instance.NotifyImages();
            VisibilityProperties.Instance.PastePanelVisibility = false;
            VisibilityProperties.Instance.NotifyProperties();
            Images.Instance.NotifyImages();

        }
        #endregion
        /// <summary>
        /// Set hue
        /// </summary>
        #region Hue
        private int huevalue = 0;
        public int HueValue
        {
            get
            {
                return this.huevalue;
            }
            set
            {
                this.huevalue = value;
                NotifyPropertyChanged("HueValue");
            }
        }

        private readonly HueModifier hueFiltter = new HueModifier();
        private ICommand changehue;
        public ICommand ChangeHue
        {
            get
            {
                if (this.changehue == null)
                {
                    this.changehue = new RelayCommand(this.ChangeHueC);
                }
                return this.changehue;
            }
        }
        private void ChangeHueC(object obj)
        {

            Bitmap bmp = null;
            try
            {
                bmp = (Bitmap)this.Temporary.Clone();
            }
            catch
            { }
            hueFiltter.Hue = HueValue;
            if (bmp != null)
            {
                hueFiltter.ApplyInPlace(bmp);
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

        private ICommand sethue;
        public ICommand SetHue
        {
            get
            {
                if (this.sethue == null)
                {
                    this.sethue = new RelayCommand(this.SetHueC);
                }
                return this.sethue;
            }
        }
        private void SetHueC(object obj)
        {
            UndoRedoModel.Instance.UndoStack.Push(this.Temporary);
            Images.Instance.UndoBr++;
            this.Temporary = Images.Instance.CurrentBitmap;
        }
        #endregion

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
