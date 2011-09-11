using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slambot
{
    /// <summary>
    /// RGBD callback type
    /// </summary>
    /// <param name="rgb">RGB Image</param>
    /// <param name="depth">Depth Image as 16 bit grayscale</param>
    public delegate UInt64 RGBDCallback(System.Drawing.Image rgb, System.Drawing.Image depth);

    interface IRGBDImageSource
    {
        /// <summary>
        /// Sets the max rate of images allowed to come from the RGBDImageSource.  Images will be discarded to
        /// keep them from arriving faster than the interval set here.
        /// </summary>
        /// <param name="seconds">interval in seconds</param>
        void SetFrameInterval(Double seconds);

        /// <summary>
        /// Register an RGBDCallback.  All callbacks will be allowed to finish, even if Images must be
        /// discarded until then.
        /// </summary>
        /// <param name="cb">the callback delegate</param>
        void RegisterRGBDCallback(RGBDCallback cb);
    }
}
