using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Drawing.Imaging;

namespace Slambot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int whichImageNumber = 0;

        public MainWindow()
        {
            InitializeComponent();

        }

        protected void ConvertToWPF(System.Drawing.Image gdilmg, System.Windows.Controls.Image targetImage)
        {
            //convert System.Drawing.Image to WPF Image
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(gdilmg);
            IntPtr hBitmap = bmp.GetHbitmap();
            System.Windows.Media.ImageSource WpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            targetImage.Source = WpfBitmap;
            targetImage.Width = RGBImage.Width;
            targetImage.Height = RGBImage.Height;
            targetImage.Stretch = RGBImage.Stretch;
        } // end of convertToWpf

        public BitmapSource loadPng(String fromPath)
        {
            Stream imageStreamSource = new FileStream(fromPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            PngBitmapDecoder decoder = new PngBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];
            return bitmapSource;
        }

        public void onClick(object sender, RoutedEventArgs e) 
        {
            if (whichImageNumber < 11 && !(RGBImage.Equals(null)) && !(DepthImage.Equals(null)))
            {
                whichImageNumber += 5;
                //FFV: This needs to be implemented later to use the iterator instead of hardcoding it for the individual images
                RGBImage.Source = loadPng("Data\\image760.png");
                DepthImage.Source = loadPng("Data\\depth760.png");
            } //end of if
        } //end of onClick()

    } //end of MainWindow
} //end of program
