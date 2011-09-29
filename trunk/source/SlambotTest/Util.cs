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
using System.Drawing.Imaging;

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
            /*Stream imageStreamSource = new FileStream("Data\\image"+i+".tiff", FileMode.Open, FileAccess.Read, FileShare.Read);
            TiffBitmapDecoder decoder = new TiffBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];
            Bitmap bmp = new Bitmap(bitmapSource.PixelWidth,bitmapSource.PixelHeight,System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            BitmapData data = bmp.LockBits(new Rectangle(System.Drawing.Point.Empty, bmp.Size),ImageLockMode.WriteOnly,System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            bitmapSource.CopyPixels(Int32Rect.Empty,data.Scan0,data.Height * data.Stride,data.Stride);
            bmp.UnlockBits(data);
            return bmp;*/
            return Image.FromFile("Data\\image"+i+".png"); 
        }

        /// <summary>
        /// Load a test Depth Image from the Data directory
        /// </summary>
        /// <param name="i">Image index</param>
        /// <returns>Depth Image</returns>
        static public Image GetDepth(int i)
        {
            /*Stream imageStreamSource = new FileStream("Data\\image" + i + ".tiff", FileMode.Open, FileAccess.Read, FileShare.Read);
            TiffBitmapDecoder decoder = new TiffBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];
            System.Drawing.Bitmap btm = null;
            int width = bitmapSource.PixelWidth;
            int height = bitmapSource.PixelHeight;
            int stride = width * ((bitmapSource.Format.BitsPerPixel + 7) / 8);
            IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocHGlobal(height * stride);
            bitmapSource.CopyPixels(new Int32Rect(0, 0, width, height), ptr, height * stride, stride);
            btm = new System.Drawing.Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, ptr);
            return btm;*/
            return Image.FromFile("Data\\depth" + i + ".png");
        }
    }
}
