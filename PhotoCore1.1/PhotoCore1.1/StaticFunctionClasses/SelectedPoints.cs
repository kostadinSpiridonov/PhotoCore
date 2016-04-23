using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using PhotoCore1._1.Models;
namespace PhotoCore1._1.StaticFunctionClasses
{
    public static class SelectedPoints
    {

        private static System.Windows.Point pointdown;
        public static System.Windows.Point PointDown
        {
            get
            {
                return pointdown;
            }
            set
            {
                pointdown = value;
            }
        }

        private static System.Windows.Point pointup;
        public static System.Windows.Point PointUp
        {
            get
            {
                return pointup;
            }
            set
            {
                pointup = value;
            }
        }

        private static System.Windows.Point pickerpoint;
        public static System.Windows.Point PickerPoint
        {
            get
            {
                return pickerpoint;
            }
            set
            {
                pickerpoint = value;
            }
        }

        private static System.Windows.Point textboxpoint;
        public static System.Windows.Point TextBoxPoint
        {
            get
            {
                return textboxpoint;
            }
            set
            {
                textboxpoint = value;
            }
        }

        private static System.Windows.Point mergepoint;
        public static System.Windows.Point MergePoint
        {
            get
            {
                return mergepoint;
            }
            set
            {
                mergepoint = value;
            }
        }

        public static int selectPointForEfX { get; set; }
        public static int selectPointForEfY { get; set; }
    }
}
