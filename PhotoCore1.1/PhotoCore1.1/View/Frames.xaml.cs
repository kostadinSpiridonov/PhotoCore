using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PhotoCore1._1.View
{
    /// <summary>
    /// Interaction logic for Frames.xaml
    /// </summary>
    public partial class Frames 
    {
        public Frames()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void KeyCombinations(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
