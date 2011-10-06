using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Slambot
{
    /// <summary>
    /// RGBDSourceTester pumps new Images into the SLAM system using PumpNewRGBD().
    /// Otherwise it is a trivial implementation of IRGBDImageSource.
    /// </summary>
    public class RGBDSourceManualPump : IRGBDImageSource
    {
        protected List<RGBDCallback> cbList;
        protected String filePath="";
        protected int imageMultiple=10;
        protected int whichImageNumber=0;

        public RGBDSourceManualPump()
        {
            cbList = new List<RGBDCallback>();
        }

        public RGBDSourceManualPump(String filePath, int imageMultiple=10, int whichImageNumber=0)
        {
            cbList = new List<RGBDCallback>();
            this.filePath = filePath;
            this.imageMultiple = imageMultiple;
            this.whichImageNumber = whichImageNumber;
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

        public UInt64 AutoPump()
        {
            if (whichImageNumber > 1000)
            {
                whichImageNumber=0;
            }

            else
            {
                whichImageNumber += imageMultiple;
            }

            return PumpNewRGBD(System.Drawing.Image.FromFile(filePath+"\\image" + whichImageNumber + ".png"),
                    System.Drawing.Image.FromFile(filePath+"\\depth" + whichImageNumber + ".png"));
        }
    }
}
