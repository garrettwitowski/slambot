using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

using System.Drawing;

namespace SlambotTest
{
    public static class Util
    {
        /// <summary>
        /// Load a test RGB Image from the Data directory
        /// </summary>
        /// <param name="i">Image index</param>
        /// <returns>RGB Image</returns>
        static public Image GetImage(int i)
        {

#if CODEINWORK
            Stream imageStreamSource = new FileStream("Data\\image"+i+".tiff", FileMode.Open, FileAccess.Read, FileShare.Read);
            TiffBitmapDecoder decoder = new TiffBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];
            Bitmap bmp = new Bitmap(bitmapSource.PixelWidth,bitmapSource.PixelHeight,PixelFormat.Format32bppPArgb);
            BitmapData data = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size),ImageLockMode.WriteOnly,PixelFormat.Format32bppPArgb);
            source.CopyPixels(Int32Rect.Empty,data.Scan0,data.Height * data.Stride,data.Stride);
            bmp.UnlockBits(data);
            return bmp;
#endif
            return Image.FromFile("Data\\image"+i+".tiff"); 
        }

        /// <summary>
        /// Load a test Depth Image from the Data directory
        /// </summary>
        /// <param name="i">Image index</param>
        /// <returns>Depth Image</returns>
        static public Image GetDepth(int i)
        {
            return Image.FromFile("Data\\depth" + i + ".tiff");
        }
    }
}
