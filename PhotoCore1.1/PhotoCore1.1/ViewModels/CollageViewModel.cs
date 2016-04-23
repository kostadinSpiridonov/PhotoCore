using PhotoCore1._1.Commands;
using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PhotoCore1._1.ViewModels
{
    public class CollageViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// Collage images
        /// </summary>
        private ObservableCollection<BitmapImage> images = new ObservableCollection<BitmapImage>()
        {
            new BitmapImage{},new BitmapImage{},new BitmapImage{},new BitmapImage{},new BitmapImage{},
            new BitmapImage{},new BitmapImage{},new BitmapImage{},new BitmapImage{},new BitmapImage{},
            new BitmapImage{},new BitmapImage{},new BitmapImage{},new BitmapImage{},new BitmapImage{},
            new BitmapImage{},new BitmapImage{},new BitmapImage{},new BitmapImage{},new BitmapImage{}
        };
        public ObservableCollection<BitmapImage> Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
            }
        }

        /// <summary>
        /// Open one image to collage
        /// </summary>
        private ICommand open;
        public ICommand Open
        {
            get
            {
                if (this.open == null)
                {
                    this.open = new RelayCommand(this.OpenC);
                }
                return this.open;
            }
        }
        private void OpenC(object obj)
        {
            string name = obj.ToString().Remove(0,1);
            int index = int.Parse(name);
              Bitmap temporary = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.png";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream str = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                temporary = (Bitmap)Bitmap.FromStream(str, true, true);
                temporary.SetPixel(0, 0, temporary.GetPixel(0, 0));
                str.Flush();
                str.Close();
                try
                {
                    Images.RemoveAt(index);
                }
                catch {}
                Images.Insert(index,ImageConverterFormat.BitmapToBitmapImage((Bitmap)temporary.Clone()));

            }
        }

        /// <summary>
        /// Remove image from collage
        /// </summary>
        private ICommand remove;
        public ICommand Remove
        {
            get
            {
                if (this.remove == null)
                {
                    this.remove = new RelayCommand(this.RemoveC);
                }
                return this.remove;
            }
        }
        private void RemoveC(object obj)
        {
            string name = obj.ToString().Remove(0, 1);
            int index = int.Parse(name);
                try
                {
                    Images.RemoveAt(index);
                    Images.Insert(index, new BitmapImage());
                }
                catch { }
        }

        /// <summary>
        /// Save collage
        /// </summary>
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (this.save == null)
                {
                    this.save = new RelayCommand(this.SaveC);
                }
                return this.save;
            }
        }
        private void SaveC(object obj)
        {
            BitmapSource save = ImageConverterFormat.ConvertToBitmapSource(this.Collage);
            Bitmap collageImage = (Bitmap)ImageConverterFormat.GetBitmapFromSource(save).Clone();
            ImageFunction.SaveAsCurrentImage(collageImage);
        }

        /// <summary>
        /// Open collage in editor
        /// </summary>
        private ICommand openineditor;
        public ICommand OpenInEditor
        {
            get
            {
                if (this.openineditor == null)
                {
                    this.openineditor = new RelayCommand(this.OpenInEditorC);
                }
                return this.openineditor;
            }
        }
        private void OpenInEditorC(object obj)
        {

            BitmapSource save = ImageConverterFormat.ConvertToBitmapSource(this.Collage);
            Bitmap collageImage = (Bitmap)ImageConverterFormat.GetBitmapFromSource(save).Clone();

            Bitmap clone = new Bitmap(collageImage.Width, collageImage.Height, Models.Images.Instance.CurrentBitmap.PixelFormat);
            using (Graphics gr = Graphics.FromImage(clone))
            {
                gr.DrawImage(collageImage, new Rectangle(0, 0, clone.Width, clone.Height));
            }
            Models.Images.Instance.CurrentBitmap = (Bitmap)clone.Clone();
            Models.Images.Instance.UndoBr = 0;
            Models.UndoRedoModel.Instance.RedoStack = new Stack<Bitmap>();
            Models.UndoRedoModel.Instance.UndoStack = new Stack<Bitmap>();
            Models.Images.Instance.NotifyImages();
        } 

        /// <summary>
        /// Border thikness property
        /// </summary>
        private double borderthiknes=0.5;
        public double BorderThikness
        {
            get
            {
                return this.borderthiknes;
            }
            set
            {
                this.borderthiknes = value;
                NotifyPropertyChanged("BorderThikness");
            }
        }

        /// <summary>
        /// Corner raidus propery
        /// </summary>
        private double cornerradius = 0;
        public double CorderRadius
        {
            get
            {
                return this.cornerradius;
            }
            set
            {
                this.cornerradius = value;
                NotifyPropertyChanged("CorderRadius");
            }
        }

        /// <summary>
        /// Border color property
        /// </summary>
        private ColorsViewModel bordercolor = new ColorsViewModel();
        public ColorsViewModel BorderColor
        {
            get
            {
                return this.bordercolor;
            }
            set
            {
                this.bordercolor = value;
                NotifyPropertyChanged("BorderColor");
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
        /// Whole collage grid
        /// </summary>
        private System.Windows.Controls.Grid collage = new Grid();
        public Grid Collage
        {
            get
            {
                return this.collage;
            }
            set
            {
                this.collage = value;
            }
        }
    }
}
