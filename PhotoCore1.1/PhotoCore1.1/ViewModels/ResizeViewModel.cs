using PhotoCore1._1.Commands;
using PhotoCore1._1.Models;
using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoCore1._1.ViewModels
{
    public class ResizeViewModel:INotifyPropertyChanged
    {
        private bool mainratio = false;
        private double resizehor=100;
        private double resizever=100;
        private double skewhor=0;
        private double skewver=0;

        public double ResizeHorizontal
        {
            get 
            {
                return this.resizehor;
            }
            set 
            {
                if (mainratio == false)
                {
                    this.resizehor = value;
                    NotifyPropertyChanged("ResizeHorizontal");
                }
                else
                {
                    this.resizehor = value;
                    this.resizever = value;
                    NotifyPropertyChanged("ResizeVertival");
                    NotifyPropertyChanged("ResizeHorizontal");
                }
            }
        }

        public double ResizeVertival
        {
            get
            {
                return this.resizever;
            }
            set
            {
                if (mainratio == false)
                {
                    this.resizever = value;
                    NotifyPropertyChanged("ResizeVertival");
                }
                else
                {
                    this.resizever = value;
                    NotifyPropertyChanged("ResizeVertival");
                    resizehor = resizever;
                    NotifyPropertyChanged("ResizeHorizontal");
                }
            }
        }

        public double SkewHorizontal
        {
            get
            {
                return this.skewhor;
            }
            set
            {
                this.skewhor = value;                
                NotifyPropertyChanged("SkewHorizontal");
            }
        }
        
        public double SkewVertical
        {
            get
            {
                return this.skewver;
            }
            set
            {
                this.skewver = value;
                NotifyPropertyChanged("SkewVertical");
            }
        }

        public bool MainRatio
        {
            get
            {
                return this.mainratio;
            }
            set
            {
                this.mainratio = value;
                NotifyPropertyChanged("MainRatio");
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
        /// Aplly resize on bitmap
        /// </summary>
        private ICommand applyresize;
        public ICommand ApplyResize
        {
            get
            {
                if (this.applyresize == null)
                {
                    this.applyresize = new RelayCommand(this.ApplyR);
                }
                return this.applyresize;
            }
        }
        public void ApplyR(object obj)
        {
            if (ResizeHorizontal != 100 || ResizeVertival != 100 || SkewVertical != 0 || SkewHorizontal != 0)
            {
                Images.Instance.CurrentBitmap = ImageFunction.ResizeBitmap(Images.Instance.CurrentBitmap, (int)ResizeHorizontal, (int)ResizeVertival);
                Images.Instance.CurrentBitmap = ImageFunction.Skew(Images.Instance.CurrentBitmap, (int)SkewHorizontal, (int)SkewVertical);
                Images.Instance.NotifyImages();
            }
        }
    }
}
