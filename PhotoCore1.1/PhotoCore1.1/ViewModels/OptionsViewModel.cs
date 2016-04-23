using PhotoCore1._1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PhotoCore1._1.ViewModels
{
    public class OptionsViewModel:INotifyPropertyChanged
    {
        public static ObservableCollection<ColorModel> colors = new ObservableCollection<ColorModel>
        {
            new ColorModel(System.Drawing.Color.FromArgb(96,169,23)),      
            new ColorModel(System.Drawing.Color.FromArgb(27,161,226)),    
            new ColorModel(System.Drawing.Color.FromArgb(170,0,255)),    
            new ColorModel(System.Drawing.Color.FromArgb(250,104,0)),    
            new ColorModel(System.Drawing.Color.FromArgb(164,196,0)),    
            new ColorModel(System.Drawing.Color.FromArgb(0,138,0)),    
            new ColorModel(System.Drawing.Color.FromArgb(0,171,169)),    
            new ColorModel(System.Drawing.Color.FromArgb(27,161,226)),    
            new ColorModel(System.Drawing.Color.FromArgb(0,80,239)),    
            new ColorModel(System.Drawing.Color.FromArgb(106,0,255)),    
            new ColorModel(System.Drawing.Color.FromArgb(43,87,151)),    
            new ColorModel(System.Drawing.Color.FromArgb(244,114,208)),    
            new ColorModel(System.Drawing.Color.FromArgb(216,0,115)),    
            new ColorModel(System.Drawing.Color.FromArgb(162,0,37)),    
            new ColorModel(System.Drawing.Color.FromArgb(250,104,0)),    
            new ColorModel(System.Drawing.Color.FromArgb(240,163,10))  
        };

        public ObservableCollection<ColorModel> Colors
        {
            get
            {
                return colors;
            }
            set
            {
                colors = value;
            }
        }
        private ColorModel selectedcolor = new ColorModel(System.Drawing.Color.FromArgb(45, 137, 239));
        public ColorModel SelectedColor
        {
            get
            {
                return this.selectedcolor;
            }
            set
            {
                this.selectedcolor = value;
                NotifyPropertyChanged("SelectedColor");
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
    }
}
