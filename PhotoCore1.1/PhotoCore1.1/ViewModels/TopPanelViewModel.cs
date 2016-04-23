using PhotoCore1._1.Commands;
using PhotoCore1._1.Models;
using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Input;

namespace PhotoCore1._1.ViewModels
{
    public class TopPanelViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// Open image
        /// </summary>
        #region Open
        private ICommand open;
        public ICommand Open
        {
            get
            {
                if (this.open == null)
                {
                    this.open = new RelayCommand(this.OpenImage);
                }
                return this.open;
            }
        }
        private void OpenImage(object obj)
        {
            Bitmap a = (Bitmap)ImageFunction.OpenNewQuestion().Clone();
            Images.Instance.CurrentBitmap = ImageFunction.OpenImage();
            Images.Instance.OriginalBitmap = Images.Instance.CurrentBitmap;
            Images.Instance.Frame = null;
            VisibilityProperties.Instance.FrameVisibility = false;
            Images.Instance.NotifyImages();
            UndoRedoModel.Instance.RedoStack.Clear();
            UndoRedoModel.Instance.UndoStack.Clear();
            Images.Instance.UndoBr = 0;
        }
        #endregion
        /// <summary>
        /// Set new list
        /// </summary>
        #region NewList
        private ICommand newlist;
        public ICommand NewList
        {
            get
            {
                if (this.newlist == null)
                {
                    this.newlist = new RelayCommand(this.SetNewList);
                }
                return this.newlist;
            }
        }
        private void SetNewList(object obj)
        {
            Bitmap a = (Bitmap)ImageFunction.NewQuestion().Clone();
            Images.Instance.Frame = null;
            VisibilityProperties.Instance.FrameVisibility=false;
            Images.Instance.OriginalBitmap = Images.Instance.CurrentBitmap;
            Images.Instance.BitmapPath = null;
            Images.Instance.CurrentBitmap = (Bitmap)a.Clone();
            Images.Instance.NotifyImages();
            VisibilityProperties.Instance.NewListBorder = true;
            VisibilityProperties.Instance.SelectRectangleVisibility = false;
            VisibilityProperties.Instance.NotifyProperties();
            UndoRedoModel.Instance.RedoStack = new Stack<Bitmap>();
            UndoRedoModel.Instance.UndoStack = new Stack<Bitmap>();
           Images.Instance.UndoBr=0;
        }
        #endregion
        /// <summary>
        /// Save the image
        /// </summary>
        #region Save
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (this.save == null)
                {
                    this.save = new RelayCommand(this.SaveImage);
                }
                return this.save;
            }
        }
        public void SaveImage(object obj)
        {
            if (Images.Instance.CurrentBitmap != null)
            {
                Images.Instance.DrawFrame();
                if(Images.Instance.BitmapPath!=null)
                { 
                ImageFunction.SaveCurrentImage(Images.Instance.CurrentBitmap,Images.Instance.BitmapPath);
                }
                else
                {
                    SaveAsImage(obj);
                }
            }
        }
        #endregion
        /// <summary>
        /// Save as the image
        /// </summary>
        #region SaveAs
        private ICommand saveas;
        public ICommand SaveAs
        {
            get
            {
                if (this.saveas == null)
                {
                    this.saveas = new RelayCommand(this.SaveAsImage);
                }
                return this.saveas;
            }
        }
        private void SaveAsImage(object obj)
        {
            if (Images.Instance.CurrentBitmap != null)
            {
                Images.Instance.DrawFrame();
                ImageFunction.SaveAsCurrentImage(Images.Instance.CurrentBitmap);
            }
        }
        #endregion
        /// <summary>
        /// Close the program
        /// </summary>
        #region Exit
        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                if (this.exit == null)
                {
                    this.exit = new RelayCommand(this.ExitApplication);
                }
                return this.exit;
            }
        }
        private void ExitApplication(object obj)
        {
            System.Windows.Application.Current.Shutdown();

        }
        #endregion
        /// <summary>
        /// Rotate the image
        /// </summary>
        #region Rotate
        private ICommand rotateRight;
        public ICommand RotateRight
        {
            get
            {
                if (this.rotateRight == null)
                {
                    this.rotateRight = new RelayCommand(this.RotateR);
                }
                return this.rotateRight;
            }
        }
        private void RotateR(object obj)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
                System.Windows.MessageBox.Show(Language.CurrentLanguage[95]);
            }
            else
            {
                if (Images.Instance.CurrentBitmap != null)
                {
                    Bitmap a = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                    Images.Instance.CurrentBitmap = ImageFunction.RotateFlip(RotateFlipType.Rotate90FlipNone, a);
                    Images.Instance.NotifyImages();
                }
            }
        }

        private ICommand rotateLeft;
        public ICommand RotateLeft
        {
            get
            {
                if (this.rotateLeft == null)
                {
                    this.rotateLeft = new RelayCommand(this.RotateL);
                }
                return this.rotateLeft;
            }
        }
        private void RotateL(object obj)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
               System.Windows.MessageBox.Show(Language.CurrentLanguage[95]);
            }
            else
            {
                if (Images.Instance.CurrentBitmap != null)
                {
                    Bitmap a = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                    Images.Instance.CurrentBitmap = ImageFunction.RotateFlip(RotateFlipType.Rotate90FlipXY, a);
                    Images.Instance.NotifyImages();
                }
            }
        }


        private ICommand flipHorizontal;
        public ICommand FlipHorizontal
        {
            get
            {
                if (this.flipHorizontal == null)
                {
                    this.flipHorizontal = new RelayCommand(this.FlipH);
                }
                return this.flipHorizontal;
            }
        }
        private void FlipH(object obj)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
               System.Windows.MessageBox.Show(Language.CurrentLanguage[95]);
            }
            else
            {
                if (Images.Instance.CurrentBitmap != null)
                {
                    Bitmap a = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                    Images.Instance.CurrentBitmap = ImageFunction.RotateFlip(RotateFlipType.Rotate180FlipX, a);
                    Images.Instance.NotifyImages();
                }
            }
        }

        private ICommand flipVertical;
        public ICommand FlipVertical
        {
            get
            {
                if (this.flipVertical == null)
                {
                    this.flipVertical = new RelayCommand(this.FlipV);
                }
                return this.flipVertical;
            }
        }
        private void FlipV(object obj)
        {
            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
               System.Windows.MessageBox.Show(Language.CurrentLanguage[95]);
            }
            else
            {
                if (Images.Instance.CurrentBitmap != null)
                {
                    Bitmap a = (Bitmap)Images.Instance.CurrentBitmap.Clone();
                    Images.Instance.CurrentBitmap = ImageFunction.RotateFlip(RotateFlipType.Rotate180FlipY, a);
                    Images.Instance.NotifyImages();
                }
            }
        }
        #endregion
        /// <summary>
        /// Crop the selected bitmap
        /// </summary>
        #region Crop
        private ICommand crop;
        public ICommand Crop
        {
            get
            {
                if (this.crop == null)
                {
                    this.crop = new RelayCommand(this.CropS);
                }
                return this.crop;
            }
        }

        private void CropS(object obj)
        {
            if (Images.Instance.SelectedBitmap != null)
            {
                Images.Instance.CurrentBitmap = (Bitmap)Images.Instance.SelectedBitmap.Clone();
                Images.Instance.NotifyImages();
                VisibilityProperties.Instance.SelectRectangleVisibility = false;
                VisibilityProperties.Instance.NotifyProperties();
                Images.Instance.SelectedBitmap = null;
                VisibilityProperties.Instance.NewListBorder = false;
                VisibilityProperties.Instance.NotifyProperties();
            }
        }
        #endregion
        /// <summary>
        /// Paste the content from the clipboard
        /// </summary>
        #region Paste
        private ICommand paste;
        public ICommand Paste
        {
            get
            {
                if (this.paste == null)
                {
                    this.paste = new RelayCommand(this.PasteC);
                }
                return this.paste;
            }
        }

        public void PasteC(object obj)
        {

            if (VisibilityProperties.Instance.FrameVisibility == true)
            {
               System.Windows.MessageBox.Show(Language.CurrentLanguage[95]);
            }
            else
            {
                VisibilityProperties.Instance.ImageCursor = System.Windows.Input.Cursors.Arrow;
                VisibilityProperties.Instance.SelectRectangleVisibility = false;
                VisibilityProperties.Instance.NotifyProperties();
                var data = System.Windows.Forms.Clipboard.GetImage();
                if (data != null)
                {
                    if (Images.Instance.CurrentBitmap != null)
                    {
                        VisibilityProperties.Instance.PastePanelVisibility = true;
                        VisibilityProperties.Instance.NotifyProperties();
                        Images.Instance.PasteBitmap = (Bitmap)ImageFunction.SetClipboardImageToBitmap().Clone();
                        Images.Instance.NotifyImages();
                    }
                    else if (Images.Instance.CurrentBitmap == null)
                    {
                        Images.Instance.CurrentBitmap = (Bitmap)ImageFunction.SetClipboardImageToBitmap().Clone();
                        Images.Instance.NotifyImages();
                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// Copy the slected bitmap
        /// </summary>
        #region Copy
        private ICommand copy;
        public ICommand Copy
        {
            get
            {
                if (this.copy == null)
                {
                    this.copy = new RelayCommand(this.CopyC);
                }
                return this.copy;
            }
        }

        public void CopyC(object obj)
        {
                if (Images.Instance.SelectedBitmap != null)
                {
                    System.Windows.Forms.Clipboard.SetImage(Images.Instance.SelectedBitmap);
                }
                else if (Images.Instance.SelectedBitmap == null)
                {
                    System.Windows.Forms.Clipboard.SetImage(Images.Instance.CurrentBitmap);
                }
        }
        #endregion
        /// <summary>
        /// Sut the selcted bitmap
        /// </summary>
        #region Cut
        private ICommand cut;
        public ICommand Cut
        {
            get
            {
                if (this.cut == null)
                {
                    this.cut = new RelayCommand(this.CutC);
                }
                return this.cut;
            }
        }

        public void CutC(object obj)
        {
            if (Images.Instance.SelectedBitmap != null)
            {
                System.Windows.Forms.Clipboard.SetImage(Images.Instance.SelectedBitmap);
                Images.Instance.CurrentBitmap =(Bitmap) ImageFunction.Clear_Selected_Area(Images.Instance.CurrentBitmap).Clone();
                Images.Instance.SelectedBitmap = null;
                Images.Instance.NotifyImages();
                VisibilityProperties.Instance.SelectRectangleVisibility = false;
                VisibilityProperties.Instance.NotifyProperties();
            }
        }
        #endregion
        /// <summary>
        /// Set font to textbox
        /// </summary>
        #region Font
        private int fontsize=11;
        public int FontSize
        {
            get
            {
                return this.fontsize; 
            }
            set
            {
                this.fontsize = value;
                NotifyPropertyChanged("FontSize");
            }
        }
        private System.Windows.Media.FontFamily fontfamily= new System.Windows.Media.FontFamily("Arial");
        public System.Windows.Media.FontFamily FontFamily
        {
            get
            {
                return this.fontfamily;
            }
            set
            {
                this.fontfamily = value;
                NotifyPropertyChanged("FontFamily");
            }
        }
        #endregion
        /// <summary>
        /// Undo and redo command
        /// </summary>
        #region Undo Redo
        private ICommand undo;
        public ICommand Undo
        {
            get
            {
                if (this.undo == null)
                {
                    this.undo = new RelayCommand(this.UndoC);
                }
                return this.undo;
            }
        }

        public void UndoC(object obj)
        {
            if (UndoRedoModel.Instance.UndoStack.Count!=0)
            {
                    UndoRedoModel.Instance.RedoStack.Push(Images.Instance.CurrentBitmap);
                    Bitmap q=UndoRedoModel.Instance.UndoStack.Pop();
                    Images.Instance.CurrentBitmap = (Bitmap)q.Clone();
                    Images.Instance.NotifyImages();
                    Images.Instance.UndoBr--;
            }
        }

        private ICommand redo;
        public ICommand Redo
        {
            get
            {
                if (this.redo == null)
                {
                    this.redo = new RelayCommand(this.RedoC);
                }
                return this.redo;
            }
        }

        public void RedoC(object obj)
        {
            if (UndoRedoModel.Instance.RedoStack.Count != 0)
            {
                UndoRedoModel.Instance.UndoStack.Push(Images.Instance.CurrentBitmap);
                Bitmap q = UndoRedoModel.Instance.RedoStack.Pop();
                Images.Instance.CurrentBitmap = (Bitmap)q.Clone();
                Images.Instance.NotifyImages();
                Images.Instance.UndoBr++;
            }
        }
        #endregion
        /// <summary>
        /// Frames window option
        /// </summary>
        #region Frames
        private ICommand removeframe;
        public ICommand RemoveFrame
        {
            get
            {
                if (this.removeframe == null)
                {
                    this.removeframe = new RelayCommand(this.RemoveFrameC);
                }
                return this.removeframe;
            }
        }

        private void RemoveFrameC(object obj)
        {
            Images.Instance.Frame = null;
            Images.Instance.NotifyImages();
            VisibilityProperties.Instance.FrameVisibility = false;

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
