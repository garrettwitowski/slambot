using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slambot
{
    public struct Landmark
    {
        public Double PixelX { get; set; }
        public Double PixelY { get; set; }
        public String info { get; set; }
        public Landmark(Double PixelX, Double PixelY, String info):this()
        {
            this.PixelX = PixelX;
            this.PixelY = PixelY;
            this.info = info;
        }
    }

    public class LandmarkIdentifierBase
    {
        IFrameStore fs = null;
        static String LandmarkTypeKey = "BaseLandmarks";
        static String LandmarkListKey = "Landmarks";


        public void OnNewFrame(UInt64 id)
        {
            //Find all Landmarks
            var landmarks = new List<Landmark>();
            landmarks.Add(new Landmark(15,15,"red"));
            landmarks.Add(new Landmark(50,25,"green"));
            landmarks.Add(new Landmark(25,50,"blue"));

            //Add the new landmarks to the attributes
            fs.GetAttributes(id).Add(LandmarkTypeKey, landmarks);
        }

        public LandmarkIdentifierBase(CallbackManager cbm)
        {
            //Register the callback and remember our framestore
            fs = cbm.RegisterFrameCallback(OnNewFrame, CallbackManager.Priority.FindLandmarks);
            //Add ourselves to the list of landmark types
            Object llk;
            if (fs.GetConfig().TryGetValue(LandmarkListKey, out llk))
            {
                //Found the LLK.  Let's add ourselves.
                var llkString = (List<String>)llk;
                llkString.Add(LandmarkTypeKey);
            }
            else
            {
                //Didn't find the LLK.  Let's make it and add ourselves.
                var llkString = new List<String>();
                llkString.Add(LandmarkTypeKey);
                fs.GetConfig().Add(LandmarkListKey, llkString);
            }
        }
    }
}
