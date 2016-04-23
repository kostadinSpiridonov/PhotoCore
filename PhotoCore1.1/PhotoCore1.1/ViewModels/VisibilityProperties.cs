using PhotoCore1._1.Models;
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
    /// <summary>
    /// Visibility properties for binding
    /// </summary>
    public class VisibilityProperties : INotifyPropertyChanged
    {
        private static readonly VisibilityProperties instance = new VisibilityProperties();
        public VisibilityProperties()
        {
            selectcanvasvisibility=false;
            pastepanelvisibility = false;
            selectrectanglevisibility = false;
            newlistborder = true;
            pickerselected = false;
            inkcanvasvisibility = false;
            inserttextvisibiliry = false;
            textbuttonchecked = false;
            textpanelisselected = false;
            homepanelisselected = true;
            rightpanel = false;
            clearbuttonvisibility=true;
            framevisibility = false;
        }
        public static VisibilityProperties Instance
        {
            get
            {
                return instance;
            }
        }

        private bool selectcanvasvisibility;
        public bool SelectCanvasVisibility
        {
            get
            {
                return selectcanvasvisibility;
            }
            set
            {
                this.selectcanvasvisibility = value;
            }
        }

        private bool selectrectanglevisibility;
        public bool SelectRectangleVisibility
        {
            get
            {
                return selectrectanglevisibility;
            }
            set
            {
                this.selectrectanglevisibility = value;
            }
        }

        private bool pastepanelvisibility;
        public bool PastePanelVisibility
        {
            get
            {
                return pastepanelvisibility;
            }
            set
            {
                this.pastepanelvisibility = value;
            }
        }

        private bool newlistborder;
        public bool NewListBorder
        {
            get
            {
                return newlistborder;
            }
            set
            {
                this.newlistborder = value;
            }
        }

        private bool pickerselected;
        public bool PickerSelected
        {
            get
            {
                return pickerselected;
            }
            set
            {
                this.pickerselected = value;
            }
        }

        private bool inkcanvasvisibility;
        public bool InkCanvasVisibility
        {
            get
            {
                return inkcanvasvisibility;
            }
            set
            {
                this.inkcanvasvisibility = value;
                NotifyPropertyChanged("InkCanvasVisibility");
            }
        }

        private Cursor imagecursor= Cursors.Arrow;
        public Cursor ImageCursor
        {
            get
            {
                return imagecursor;
            }
            set
            {
                this.imagecursor = value;
                NotifyPropertyChanged("ImageCursor");
            }
        }

        private bool inserttextvisibiliry;
        public bool InsertTextVisibility
        {
            get
            {
                return inserttextvisibiliry;
            }
            set
            {
                this.inserttextvisibiliry = value;
            }
        }

        private bool textbuttonchecked;
        public bool TextButtonChecked
        {
            get
            {
                return textbuttonchecked;
            }
            set
            {
                this.textbuttonchecked = value;
            }
        }

        private bool textpanelisselected;
        public bool TextPanelIsSelected
        {
            get
            {
                return textpanelisselected;
            }
            set
            {
                this.textpanelisselected = value;
            }
        }
        
        private bool homepanelisselected;
        public bool HomePanelIsSelected
        {
            get
            {
                return homepanelisselected;
            }
            set
            {
                this.homepanelisselected = value;
            }
        }

        private bool rightpanel;
        public bool RightPanel
        {
            get
            {
                return rightpanel;
            }
            set
            {
                this.rightpanel = value;
                NotifyPropertyChanged("RightPanel");
            }
        }

        private bool framevisibility;
        public bool FrameVisibility
        {
            get
            {
                return framevisibility;
            }
            set
            {
                if(value==true)
                {
                    if (Images.Instance.Frame != null)
                    {
                        this.framevisibility = true;
                        FrameModel f = new FrameModel(Images.Instance.Frame.Frame);
                        Bitmap b = new Bitmap(Images.Instance.CurrentBitmap.Width, Images.Instance.CurrentBitmap.Height);
                        using (Graphics g = Graphics.FromImage((System.Drawing.Image)b))
                        {
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            g.DrawImage(f.Frame, 0, 0, Images.Instance.CurrentBitmap.Width, Images.Instance.CurrentBitmap.Height);
                        }
                        Images.Instance.Frame = new FrameModel(b);
                    }
                    else
                    {
                        this.framevisibility = false;
                    }
                }
                else
                {
                    this.framevisibility = false;
                }
                NotifyPropertyChanged("FrameVisibility");
            }
        }

        private bool clearbuttonvisibility;
        public bool ClearButtonVisibility
        {
            get
            {
                return clearbuttonvisibility;
            }
            set
            {
                this.clearbuttonvisibility = value;
                NotifyPropertyChanged("ClearButtonVisibility");
            }
        }

        private void NotifyPropertyChanged(String info)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        public void NotifyProperties()
        {
            NotifyPropertyChanged("RightPanel");
            NotifyPropertyChanged("HomePanelIsSelected");
            NotifyPropertyChanged("TextPanelIsSelected");
            NotifyPropertyChanged("SelectCanvasVisibility");
            NotifyPropertyChanged("SelectRectangleVisibility");
            NotifyPropertyChanged("PastePanelVisibility");
            NotifyPropertyChanged("NewListBorder");
            NotifyPropertyChanged("PickerSelected");
            NotifyPropertyChanged("InkCanvasVisibility");
            NotifyPropertyChanged("InsertTextVisibility");
            NotifyPropertyChanged("TextButtonChecked");
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
