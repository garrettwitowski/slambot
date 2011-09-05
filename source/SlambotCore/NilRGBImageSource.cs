using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slambot
{
    public class NilRGBImageSource: IRGBDImageSource
    {
        /// <summary>
        /// Minimum allowed frame interval
        /// </summary>
        protected Double interval;

        /// <summary>
        /// Stores callback list
        /// </summary>
        protected List<RGBDCallback> cbList;

        public NilRGBImageSource()
        {
            interval = 0.0;
            cbList = new List<RGBDCallback>();
        }

        public void SetFrameInterval(Double seconds)
        {
            interval = seconds;
        }

        public void RegisterRGBDCallback(RGBDCallback cb) 
        {
            cbList.Add(cb);
        }

    }
}
