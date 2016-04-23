using PhotoCore1._1.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PhotoCore1._1.View
{
    /// <summary>
    /// Interaction logic for Collage.xaml
    /// </summary>
    public partial class Collage
    {
        public Collage()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Shor first pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowFirst_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Visible;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;
            s2.Visibility = Visibility.Hidden;
            s3.Visibility = Visibility.Hidden;
            s4.Visibility = Visibility.Hidden;
            s5.Visibility = Visibility.Hidden;
            s6.Visibility = Visibility.Hidden;
            s7.Visibility = Visibility.Hidden;
            s8.Visibility = Visibility.Hidden;
            s9.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor second pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowSecond_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Visible;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;

            s3.Visibility = Visibility.Hidden;
            s4.Visibility = Visibility.Hidden;
            s5.Visibility = Visibility.Hidden;
            s6.Visibility = Visibility.Hidden;
            s7.Visibility = Visibility.Hidden;
            s8.Visibility = Visibility.Hidden;
            s9.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor third pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowThird_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Visible;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;

            s3.Visibility = Visibility.Hidden;
            s4.Visibility = Visibility.Hidden;
            s5.Visibility = Visibility.Hidden;
            s6.Visibility = Visibility.Hidden;
            s7.Visibility = Visibility.Hidden;
            s8.Visibility = Visibility.Hidden;
            s9.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor four pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowFour_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Visible;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourteenPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;
            s7.Visibility = Visibility.Hidden;
            s8.Visibility = Visibility.Hidden;
            s9.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor five pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowFive_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Visible;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;
            s6.Visibility = Visibility.Hidden;
            s7.Visibility = Visibility.Hidden;
            s8.Visibility = Visibility.Hidden;
            s9.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor six pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowSix_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Visible;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;
            s8.Visibility = Visibility.Hidden;
            s9.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor seven pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowSeven_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Visible;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;
            s7.Visibility = Visibility.Hidden;
            s8.Visibility = Visibility.Hidden;
            s9.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor eight pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowEight_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Visible;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor nine pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowNine_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Visible;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor ten pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowTen_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Visible;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;
            s6.Visibility = Visibility.Hidden;
            s7.Visibility = Visibility.Hidden;
            s8.Visibility = Visibility.Hidden;
            s9.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor eleven pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowEleven_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Visible;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;
            s9.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor twelve pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowTwelve_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Visible;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;
            s4.Visibility = Visibility.Hidden;
            s5.Visibility = Visibility.Hidden;
            s6.Visibility = Visibility.Hidden;
            s7.Visibility = Visibility.Hidden;
            s8.Visibility = Visibility.Hidden;
            s9.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor thirteen pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowThirteen_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Visible;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;
            s9.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor fourteen pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowFourteen_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Visible;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;
            s4.Visibility = Visibility.Hidden;
            s5.Visibility = Visibility.Hidden;
            s6.Visibility = Visibility.Hidden;
            s7.Visibility = Visibility.Hidden;
            s8.Visibility = Visibility.Hidden;
            s9.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor fiftheen pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowFiftheen_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Visible;
            SixteenPattern.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }
        /// <summary>
        /// Shor sixteen pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowSixteen_Click(object sender, RoutedEventArgs e)
        {
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Visible;
            s4.Visibility = Visibility.Hidden;
            s5.Visibility = Visibility.Hidden;
            s6.Visibility = Visibility.Hidden;
            s7.Visibility = Visibility.Hidden;
            s8.Visibility = Visibility.Hidden;
            s9.Visibility = Visibility.Hidden;
            s10.Visibility = Visibility.Hidden;
            s11.Visibility = Visibility.Hidden;
            s12.Visibility = Visibility.Hidden;
            s13.Visibility = Visibility.Hidden;
            s14.Visibility = Visibility.Hidden;
            s15.Visibility = Visibility.Hidden;
            s16.Visibility = Visibility.Hidden;
            HideButtons();
        }

        private void HideButtons()
        {
            ButtonsCollage.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Shor collage buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToCollageButton(object sender, RoutedEventArgs e)
        {
            ButtonsCollage.Visibility = Visibility.Visible;
            FirstPattern.Visibility = Visibility.Hidden;
            SeconPattern.Visibility = Visibility.Hidden;
            ThreePattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FivePattern.Visibility = Visibility.Hidden;
            SixPattern.Visibility = Visibility.Hidden;
            SevenPattern.Visibility = Visibility.Hidden;
            EightPattern.Visibility = Visibility.Hidden;
            NinePattern.Visibility = Visibility.Hidden;
            TenPattern.Visibility = Visibility.Hidden;
            ElevenPattern.Visibility = Visibility.Hidden;
            TwelvePattern.Visibility = Visibility.Hidden;
            ThirteenPattern.Visibility = Visibility.Hidden;
            FourPattern.Visibility = Visibility.Hidden;
            FiftheenPattern.Visibility = Visibility.Hidden;
            SixteenPattern.Visibility = Visibility.Hidden;
            s0.Visibility = Visibility.Visible;
            s1.Visibility = Visibility.Visible;
            s2.Visibility = Visibility.Visible;
            s3.Visibility = Visibility.Visible;
            s4.Visibility = Visibility.Visible;
            s5.Visibility = Visibility.Visible;
            s6.Visibility = Visibility.Visible;
            s7.Visibility = Visibility.Visible;
            s8.Visibility = Visibility.Visible;
            s9.Visibility = Visibility.Visible;
            s10.Visibility = Visibility.Visible;
            s11.Visibility = Visibility.Visible;
            s12.Visibility = Visibility.Visible;
            s13.Visibility = Visibility.Visible;
            s14.Visibility = Visibility.Visible;
            s15.Visibility = Visibility.Visible;
            s16.Visibility = Visibility.Visible;
            for (int i = 0; i < (this.DataContext as BaseViewModel).CollageViewModel.Images.Count; i++)
            {
                (this.DataContext as BaseViewModel).CollageViewModel.Images[i] = new BitmapImage();
            }
            (this.DataContext as BaseViewModel).CollageViewModel.CorderRadius = 0;
            (this.DataContext as BaseViewModel).CollageViewModel.BorderThikness = 0.5;
        }
    }
}
