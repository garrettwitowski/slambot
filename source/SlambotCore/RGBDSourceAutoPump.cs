using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Drawing;
using System.Windows.Threading;

namespace Slambot
{
    /// <summary>
    /// This class pumps images automatically
    /// on the UI Thread. It runs forever once it's started.
    /// Useful for playback of RGBD Images.
    /// </summary>
    public class RGBDSourceAutoPump:RGBDSourceManualPump
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        public RGBDSourceAutoPump():base()
        {
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += new EventHandler(OnTimedEvent);
        }

        public RGBDSourceAutoPump(String filePath, int imageMultiple, int whichImageNumber, float time):base(filePath,imageMultiple,whichImageNumber)
        {
            int seconds = (int) Math.Floor(time);
            int ms = (int)((time - seconds) * 1000);
            timer.Interval = new TimeSpan(0, 0, 0, seconds, ms);
            timer.Tick += new EventHandler(OnTimedEvent);
        }

        public void Start()
        {
            timer.Start();
        }

        public void OnTimedEvent(object source, EventArgs e)
        {
            base.AutoPump();
        }

    }
}
