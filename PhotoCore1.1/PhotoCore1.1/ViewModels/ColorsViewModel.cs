using PhotoCore1._1.Commands;
using PhotoCore1._1.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace PhotoCore1._1.ViewModels
{
    public class ColorsViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// Colors collection
        /// </summary>
        public static ObservableCollection<ColorModel> colors = new ObservableCollection<ColorModel>
        {
            new ColorModel(System.Drawing.Color.Black),
            new ColorModel(System.Drawing.Color.DarkGray),
            new ColorModel(System.Drawing.Color.DarkRed),
            new ColorModel(System.Drawing.Color.Olive),
            new ColorModel(System.Drawing.Color.Green),
            new ColorModel(System.Drawing.Color.Teal),
            new ColorModel(System.Drawing.Color. Navy),
            new ColorModel(System.Drawing.Color.Purple),    
            new ColorModel(System.Drawing.Color.White),
            new ColorModel(System.Drawing.Color.Silver),
            new ColorModel(System.Drawing.Color.Red),
            new ColorModel(System.Drawing.Color.Yellow),       
            new ColorModel(System.Drawing.Color.Lime),      
            new ColorModel(System.Drawing.Color.Cyan),        
            new ColorModel(System.Drawing.Color.Blue),      
            new ColorModel(System.Drawing.Color.BlanchedAlmond),      
            new ColorModel(System.Drawing.Color.DodgerBlue),     
            new ColorModel(System.Drawing.Color.DarkOrchid),      
            new ColorModel(System.Drawing.Color.Violet),       
            new ColorModel(System.Drawing.Color.SlateGray),      
            new ColorModel(System.Drawing.Color.Goldenrod),      
            new ColorModel(System.Drawing.Color.OrangeRed),     
            new ColorModel(System.Drawing.Color.DarkGoldenrod),   
            new ColorModel(System.Drawing.Color.Tomato)      
        };
        public ObservableCollection<ColorModel> Colors
        {
            get
            {
                return colors;
            }
            set
            {
                colors=value;
            }
        }

        /// <summary>
        /// Main color property
        /// </summary>
        public ColorModel maincolor = new ColorModel(System.Drawing.Color.Black);
        public ColorModel MainColor
        {
            get
            {
                return maincolor;
            }
            set
            {
                maincolor = value;
                NotifyPropertyChanged("MainColor");
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
        /// Select color from pallete
        /// </summary>
        #region SelectColor
        private ICommand selectcolor;
        public ICommand SelectColor
        {
            get
            {
                if (this.selectcolor == null)
                {
                    this.selectcolor = new RelayCommand(this.SelectColorC);
                }
                return this.selectcolor;
            }
        }

        private void SelectColorC(object obj)
        {
            var dialog = new System.Windows.Forms.ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var dialogcolor = System.Drawing.Color.FromArgb(dialog.Color.A, dialog.Color.R, dialog.Color.G, dialog.Color.B);
                colors.Add(new ColorModel(dialogcolor));
            }
        }

        /// <summary>
        /// Theme color property
        /// </summary>
        private Brush themecolor = Brushes.DeepSkyBlue;
        public Brush ThemeColor
        {
            get
            {
                return themecolor;
            }
            set
            {
                themecolor = value;
                NotifyPropertyChanged("ThemeColor");
            }
        }
        #endregion
        
    }  
}
