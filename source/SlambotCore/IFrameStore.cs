using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Slambot
{
    public interface IFrameStore
    {
        UInt64 OnNewRGBD(System.Drawing.Image rgb, System.Drawing.Image depth);
        Image GetRGB(UInt64 id);
        Image GetDepth(UInt64 id);
        Dictionary<String, Object> GetAttributes(UInt64 id);
        UInt64 Count();
    }
}
