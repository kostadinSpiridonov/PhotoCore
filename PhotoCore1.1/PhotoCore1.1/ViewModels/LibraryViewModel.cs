using PhotoCore1._1.Commands;
using PhotoCore1._1.Models;
using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PhotoCore1._1.ViewModels
{
    public class LibraryViewModel:INotifyPropertyChanged
    {
        private BitmapImage baseimage= new BitmapImage();
        public static List<BitmapImage> librarycontent = new List<BitmapImage>();
        public static List<Bitmap> librarycontentBitmap = new List<Bitmap>();
        public BitmapImage BaseImage
        {
            get
            {
                return this.baseimage;
            }
            set
            {
                this.baseimage = value;
                NotifyPropertyChanged("BaseImage");
            }
        }

        private BitmapImage leftimage= new BitmapImage();
        public BitmapImage LeftImage
        {
            get
            {
                return this.leftimage;
            }
            set
            {
                this.leftimage = value;
                NotifyPropertyChanged("LeftImage");
            }
        }

        private BitmapImage rightimage= new BitmapImage();
        public BitmapImage RightImage
        {
            get
            {
                return this.rightimage;
            }
            set
            {
                this.rightimage = value;
                NotifyPropertyChanged("RightImage");
            }
        }

        private int selectedindex;
        public int SelectedIndex
        {
            get
            {
                return this.selectedindex;
            }
            set
            {
                this.selectedindex = value;
                try
                {
                    this.BaseImage = librarycontent[selectedindex];
                }
                catch { }
                try
                {
                    this.RightImage = librarycontent[selectedindex + 1];
                }
                catch 
                {
                    this.RightImage = new BitmapImage();
                }
                try
                {
                    this.LeftImage = librarycontent[selectedindex - 1];
                }
                catch 
                {
                    this.LeftImage = new BitmapImage();
                }
                NotifyPropertyChanged("RightImage");
                NotifyPropertyChanged("LeftImage");
                NotifyPropertyChanged("BaseImage");
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
        /// Open selected image in editor
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
           if(this.BaseImage!=null)
           {
               Images.Instance.CurrentBitmap = ImageConverterFormat.BitmapImageToBitmap(this.BaseImage);
               Images.Instance.NotifyImages();
               List<Bitmap> un = new List<Bitmap>(UndoRedoModel.Instance.UndoStack);
               un.Reverse();
               un.RemoveAt(this.SelectedIndex);
               UndoRedoModel.Instance.UndoStack = new Stack<Bitmap>(un);
               UndoRedoModel.Instance.RedoStack = new Stack<Bitmap>();
           }
        }

        /// <summary>
        /// Save selected image
        /// </summary>
        private ICommand savethis;
        public ICommand SaveThis
        {
            get
            {
                if (this.savethis == null)
                {
                    this.savethis = new RelayCommand(this.SaveThisC);
                }
                return this.savethis;
            }
        }
        private void SaveThisC(object obj)
        {
            if (this.BaseImage != null)
            {
                ImageFunction.SaveAsCurrentImage(ImageConverterFormat.BitmapImageToBitmap(this.BaseImage));
            }
        }

        /// <summary>
        /// Save all images
        /// </summary>
        private ICommand savelall;
        public ICommand SaveAll
        {
            get
            {
                if (this.savelall == null)
                {
                    this.savelall = new RelayCommand(this.SaveAllC);
                }
                return this.savelall;
            }
        }
        private void SaveAllC(object obj)
        {
            if (librarycontent.Count > 0)
            {
                FolderBrowserDialog f = new FolderBrowserDialog();
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    for (int i = 0; i < librarycontent.Count; i++)
                    {
                        if (File.Exists("Untitled" + i))
                        {
                            DialogResult result2 = System.Windows.Forms.MessageBox.Show(("There is file with the name " + "Untitled" + i + ".jpeg" + "! Do you want to replace it?"),
                            "Important Query",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                            if (result2 == System.Windows.Forms.DialogResult.Yes)
                            {
                                File.Delete(f.SelectedPath + "\\Untitled" + i + ".jpeg");
                                librarycontentBitmap[i].Save(f.SelectedPath + "\\Untitled" + i + ".jpeg", ImageFormat.Jpeg);
                            }
                        }
                        else
                        {
                            librarycontentBitmap[i].Save(f.SelectedPath + "\\Untitled" + i + ".jpeg", ImageFormat.Jpeg);
                        }
                     }
                }
            }
        }

        /// <summary>
        /// Show next image
        /// </summary>
        private ICommand next;
        public ICommand Next
        {
            get
            {
                if (this.next == null)
                {
                    this.next = new RelayCommand(this.NextC);
                }
                return this.next;
            }
        }
        public void NextC(object obj)
        {
            if (librarycontent.Count > 0&&SelectedIndex<librarycontent.Count-1)
            {
                SelectedIndex++;
            }
        }

        /// <summary>
        /// Show previous image
        /// </summary>
        private ICommand previous;
        public ICommand Previous
        {
            get
            {
                if (this.previous == null)
                {
                    this.previous = new RelayCommand(this.PreviousC);
                }
                return this.previous;
            }
        }
        public void PreviousC(object obj)
        {
            if (librarycontent.Count > 0 && SelectedIndex > 0)
            {
                SelectedIndex--;
            }
        }

        /// <summary>
        /// Open image on fulscreen
        /// </summary>
        private ICommand fullscreen;
        public ICommand FullScreen
        {
            get
            {
                if (this.fullscreen == null)
                {
                    this.fullscreen = new RelayCommand(this.FullScreenC);
                }
                return this.fullscreen;
            }
        }
        private void FullScreenC(object obj)
        {
            View.FullScreen fullscreen = new View.FullScreen();
            fullscreen.SetImage(this.BaseImage);
            fullscreen.ShowDialog();
        }
    }
}
