using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slambot
{
    class DisplayGarrett:DisplayBase
    {
        MainWindow window;

        public override void OnNewFrame(UInt64 id)
        {
            var rgb = fs.GetRGB(id);
            var depth = fs.GetDepth(id);
            window.UpdateGUI(rgb, depth);
            //return additional info to display
        }

        public DisplayGarrett(CallbackManager cbm,MainWindow window):base(cbm)
        {
            this.window = window;
        }

    }
}
