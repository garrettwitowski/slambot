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

using Slambot;

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

    /// <summary>
    /// RGBDSourceTester pumps new Images into the SLAM system using PumpNewRGBD().
    /// Otherwise it is a trivial implementation of IRGBDImageSource.
    /// </summary>
    public class RGBDSourceTestStub : IRGBDImageSource
    {
        protected List<RGBDCallback> cbList;

        public RGBDSourceTestStub()
        {
            cbList = new List<RGBDCallback>();
        }

        public void SetFrameInterval(Double seconds)
        {
            throw new NotImplementedException("Test stub does not implement all RGBDSource functionality.");
        }

        public void RegisterRGBDCallback(RGBDCallback cb)
        {
            cbList.Add(cb);
        }

        /// <summary>
        /// Pump a new RGBD image through the system
        /// </summary>
        /// <param name="rgb">RGB Image</param>
        /// <param name="depth">Depth Image</param>
        public UInt64 PumpNewRGBD(Image rgb, Image depth)
        {
            UInt64 returnValue = 0;
            foreach (var cb in cbList)
                returnValue = cb(rgb, depth);
            return returnValue;
        }
    }
}
