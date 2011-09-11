using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return Image.FromFile("Data\\image" + i + ".tiff");
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
