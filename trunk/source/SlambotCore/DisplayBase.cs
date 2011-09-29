using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slambot
{
    /// <summary>
    /// DisplayBase is the base class for display objects.  Please inherit from it.
    /// </summary>
    public class DisplayBase
    {
        protected IFrameStore fs = null;

        public void OnNewFrame(UInt64 id)
        {
            //Do something here in children of this class
        }

        public DisplayBase(CallbackManager cbm)
        {
            //Register the callback and remember our framestore
            fs = cbm.RegisterFrameCallback(OnNewFrame, CallbackManager.Priority.Display);
        }
    }
}
