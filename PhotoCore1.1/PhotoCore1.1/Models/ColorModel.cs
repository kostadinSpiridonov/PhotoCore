using System;
using System.Linq;
using System.Windows.Media;

namespace PhotoCore1._1.Models
{
    public class ColorModel
    {
        public ColorModel(System.Drawing.Color colT)
        {
            this.colm = colT;
            if (colm != null)
            {
                brushcolor = new SolidColorBrush(System.Windows.Media.Color.FromRgb(colm.R, colm.G, colm.B));
            }
        }
        public ColorModel() { }
    
        private System.Drawing.Color colm = new System.Drawing.Color();
        public System.Drawing.Color ColorM
        {
            get 
            {
                return this.colm;
            }
            set
            {
                this.colm = value;
                if(colm!=null)
                {
                    brushcolor = new SolidColorBrush(System.Windows.Media.Color.FromRgb(colm.R, colm.G, colm.B));
                }
            }

        }
       
        private System.Windows.Media.Brush brushcolor; 
        public System.Windows.Media.Brush BrushColor
        {
            get 
            {
                return this.brushcolor;
            }
            set
            {
                this.brushcolor = value;
            }

        }
     
    }
}
