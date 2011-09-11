using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slambot
{
    //Design Strategies
    // 1) Multiple implementations of most components
    //      * allows for easier unit testing
    //      * allows for quick (and bad) initial implementations
    //      * allows for algorithm experiementation
    // 2) Configure by Constructors
    //      * lazy (delayed) initialization not needed
    //      * examples need fewer lines of code and look simpler
    // 3) No duplicate configuration
    //      * configuration should only be specified in a single constructor,
    //        not repeated across multiple constructors

    class CallbackManager
    {
        public enum CbPriority
        {
            FindLandmarks,
            EstimatePose,
            SLAM,
            Display
        }

        /// <summary>
        /// Called after each frame is ready to be processed
        /// </summary>
        /// <param name="FrameId">Frame identifier</param>
        public delegate void FrameCallback(UInt64 FrameId);


        protected IRGBDImageSource imageSource;
        protected IFrameStore FrameStore;
        protected RGBDCallback rgbdCallback;

        //FFV: This is clunky.  Switch this code over to use something like an Array<List<FrameCallback>>?
        protected List<FrameCallback> FLCallbacks;
        protected List<FrameCallback> EPCallbacks;
        protected List<FrameCallback> SLAMCallbacks;
        protected List<FrameCallback> DisplayCallbacks;

        /// <summary>
        /// On a new RGBD image, call each of the registered callbacks in the appropriate order
        /// </summary>
        /// <param name="rgb">RGB Image</param>
        /// <param name="depth">Depth Image</param>
        /// <returns>ID in the Frame Store</returns>
        protected UInt64 OnNewRGBD(System.Drawing.Image rgb, System.Drawing.Image depth)
        {
            //Register the RGBD data with the Frame Store
            //Get the ID of the frame to pass on to the other callers
            UInt64 id;
            id = rgbdCallback(rgb, depth);
            //Call each of the callbacks in priority order
            foreach (var cb in FLCallbacks)
                cb(id);
            foreach (var cb in EPCallbacks)
                cb(id);
            foreach (var cb in SLAMCallbacks)
                cb(id);
            foreach (var cb in DisplayCallbacks)
                cb(id);
            return id;    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rgbdSource"></param>
        public CallbackManager(IRGBDImageSource rgbdSource, IFrameStore frameStore)
        {
            imageSource = rgbdSource;
            imageSource.RegisterRGBDCallback(OnNewRGBD);
            this.FrameStore = frameStore;
        }

        public void RegisterRGBDCallback(RGBDCallback Cb) 
        {
            if (rgbdCallback == null)
                throw new ArgumentException("Only a single RGBD callback can be registered");
            rgbdCallback = Cb;
        }

        public void RegisterFrameCallback(FrameCallback Cb, CbPriority Priority) 
        {
            if(Priority == CbPriority.FindLandmarks)
                FLCallbacks.Add(Cb);
            else if (Priority == CbPriority.EstimatePose)
                EPCallbacks.Add(Cb);
            else if (Priority == CbPriority.SLAM)
                SLAMCallbacks.Add(Cb);
            else if (Priority == CbPriority.Display)
                DisplayCallbacks.Add(Cb);
        }
    }
}
