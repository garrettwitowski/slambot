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

using System.IO;
using System.Windows;
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
            return Image.FromFile("Data\\image"+i+".png"); 
        }

        /// <summary>
        /// Load a test Depth Image from the Data directory
        /// </summary>
        /// <param name="i">Image index</param>
        /// <returns>Depth Image</returns>
        static public Image GetDepth(int i)
        {
            return Image.FromFile("Data\\depth" + i + ".png");
        }
    }
}
