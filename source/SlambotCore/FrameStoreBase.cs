using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace Slambot
{
    public class FrameStoreBase: IFrameStore
    {
        static protected int defaultCapacity = 1000;

        //Actual stored type is Image
        protected ArrayList rgbStore;
        protected ArrayList depthStore;

        //Actual stored type is Dictionary<String,Object>
        protected ArrayList attrStore;

        protected Boolean DoInternalCheck()
        {
            //Count all items.  We should always have the same number of RGB, Depth, and Attributes
            if ((rgbStore.Count != depthStore.Count) || (rgbStore.Count != attrStore.Count))
                return false;
            //All tests must have passed if we got this far
            return true;
        }

        public UInt64 Count()
        {
            int count = rgbStore.Count;
            if ((count != depthStore.Count) || (count != attrStore.Count))
                throw new ApplicationException("Frame Store internal storage is inconsistent and possibly corrupt");
            return (UInt64)count;
        }

        public UInt64 OnNewRGBD(System.Drawing.Image rgb, System.Drawing.Image depth)
        {
            int id;
            id = rgbStore.Add(rgb);
            depthStore.Add(depth);
            attrStore.Add(new Dictionary<String,Object>());
            return (UInt64)id; //RBG: Possible loss of sign.  Also, the return value from List.Add() is poorly documented
        }

        public FrameStoreBase()
        {
            rgbStore = new ArrayList(defaultCapacity);
            depthStore = new ArrayList(defaultCapacity);
            attrStore = new ArrayList(defaultCapacity);
        }

        public Image GetRGB(UInt64 id)
        {
            return (Image)rgbStore[(int)id];
        }

        public Image GetDepth(UInt64 id)
        {
            return (Image)depthStore[(int)id];
        }

        public Dictionary<String, Object> GetAttributes(UInt64 id)
        {
            return (Dictionary<String,Object>)attrStore[(int)id];
        }
    }
}
