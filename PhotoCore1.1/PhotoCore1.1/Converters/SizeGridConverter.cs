 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PhotoCore1._1.Converters
{
    /// <summary>
    /// Convert grid size 
    /// </summary>
    public class SizeGridConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(double)) { return null; }

            double dParentWidth = Double.Parse(value.ToString());
            if(dParentWidth%2==0)
            {
                return dParentWidth;
            }
            else
            {
                return dParentWidth - 1;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
