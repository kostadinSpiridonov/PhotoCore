using PhotoCore1._1.Commands;
using PhotoCore1._1.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Input;

namespace PhotoCore1._1.ViewModels
{
    public class FramesViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// Frames
        /// </summary>
        private ObservableCollection<FrameModel> frames = new ObservableCollection<FrameModel>
        {
            new FrameModel(new Bitmap("../../Frames/1.png")),
            new FrameModel(new Bitmap("../../Frames/2.png")),
            new FrameModel(new Bitmap("../../Frames/3.png")),
            new FrameModel(new Bitmap("../../Frames/4.png")),
            new FrameModel(new Bitmap("../../Frames/5.png")),
            new FrameModel(new Bitmap("../../Frames/6.png")),
            new FrameModel(new Bitmap("../../Frames/7.png")),
            new FrameModel(new Bitmap("../../Frames/8.png")),
            new FrameModel(new Bitmap("../../Frames/9.png")),
            new FrameModel(new Bitmap("../../Frames/10.png")),
            new FrameModel(new Bitmap("../../Frames/11.png")),
            new FrameModel(new Bitmap("../../Frames/13.png")),
            new FrameModel(new Bitmap("../../Frames/14.png")),
            new FrameModel(new Bitmap("../../Frames/15.png")),
            new FrameModel(new Bitmap("../../Frames/16.png")),
            new FrameModel(new Bitmap("../../Frames/17.png")),
            new FrameModel(new Bitmap("../../Frames/20.png")),
            new FrameModel(new Bitmap("../../Frames/21.png")),
            new FrameModel(new Bitmap("../../Frames/22.png")),
            new FrameModel(new Bitmap("../../Frames/23.png")),
            new FrameModel(new Bitmap("../../Frames/24.png")),
            new FrameModel(new Bitmap("../../Frames/25.png")),
            new FrameModel(new Bitmap("../../Frames/26.png"))
        };
        public ObservableCollection<FrameModel> Frames
        {
            get
            {
                return this.frames;
            }
            set
            {
                this.frames = value;
            }
        }
        /// <summary>
        /// Selected frame
        /// </summary>
        private FrameModel selectedframe;
        public FrameModel SelectedFrame
        {
            get
            {
                return this.selectedframe;
            }
            set
            {
                this.selectedframe = value;
                NotifyPropertyChanged("SelectedFrame");
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
        /// Set selected frame to bitmap
        /// </summary>
        private ICommand setframe;
        public ICommand SetFrame
        {
            get
            {
                if (this.setframe == null)
                {
                    this.setframe = new RelayCommand(this.SetFramec);
                }
                return this.setframe;
            }
        }
        private void SetFramec(object obj)
        {
           if(SelectedFrame!=null)
           {
               Bitmap b = new Bitmap(Images.Instance.CurrentBitmap.Width, Images.Instance.CurrentBitmap.Height);
               using (Graphics g = Graphics.FromImage((System.Drawing.Image)b))
               {
                   g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                   g.DrawImage(SelectedFrame.Frame, 0, 0, Images.Instance.CurrentBitmap.Width, Images.Instance.CurrentBitmap.Height);
               }
               SelectedFrame = new FrameModel(b);
               Images.Instance.Frame = SelectedFrame;
               Images.Instance.NotifyImages();
               VisibilityProperties.Instance.FrameVisibility = true;
               VisibilityProperties.Instance.NotifyProperties();
           }
        }
    }
}
