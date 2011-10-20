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
using System.Timers;

namespace Slambot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FrameStoreBase fs;
        CallbackManager cbm;
        LandmarkIdentifierBase lm;
        DisplayGarrett display;
        RGBDSourceAutoPump src;

        public MainWindow()
        {
            InitializeComponent();
            src = new RGBDSourceAutoPump("C:\\tim\\SLAM",10,0,0.2f);
            fs = new FrameStoreBase();
            cbm = new CallbackManager(src, fs);
            lm = new LandmarkIdentifierBase(cbm);
            display = new DisplayGarrett(cbm,this);
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
        }

        public void UpdateGUI(System.Drawing.Image myRGBImage, System.Drawing.Image myDepthImage)
        {
            ConvertToWPF(myRGBImage, RGBImage);
            ConvertToWPF(myDepthImage, DepthImage);
        }

        public void onClick(object sender, RoutedEventArgs e) 
        {
            src.Start();
        }

    } 
}
