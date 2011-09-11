using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit;

using Slambot;
using System.Drawing;

namespace SlambotTest
{
    //Helper Classes

    /// <summary>
    /// RGBDSourceTester pumps new Images into the SLAM system using PumpNewRGBD().
    /// Otherwise it is a trivial implementation of IRGBDImageSource.
    /// </summary>
    public class RGBDSourceTestStub: IRGBDImageSource 
    {
        protected List<RGBDCallback> cbList;

        public RGBDSourceTestStub()
        {
            cbList = new List<RGBDCallback>();
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
            UInt64 returnValue=0;
            foreach(var cb in cbList)
                returnValue = cb(rgb, depth);
            return returnValue;
        }
    }

    /// <summary>
    /// Increments Count on each new frame
    /// </summary>
    public class CallbackTestStub
    {
        public UInt64 Count {get;set;}
        public UInt64 LastId { get; set; }
        public void OnNewFrame(UInt64 id)
        {
            Count++;
            LastId = id;
        }
        public CallbackTestStub(CallbackManager cbm, CallbackManager.Priority priority)
        {
            cbm.RegisterFrameCallback(OnNewFrame, priority);
        }
    }

    //Actual Tests
    [TestFixture]
    class CallbackManagerTest
    {
        //Test functions
        [Test]
        public void ConstructorWorks()
        {
            var src = new RGBDSourceTestStub();
            var fs = new FrameStoreBase();
            var cbm = new CallbackManager(src, fs);
            Assert.That(cbm, Is.Not.Null);
        }

        [Test]
        public void NoRegisteredCallbacks()
        {
            var src = new RGBDSourceTestStub();
            var fs = new FrameStoreBase();
            var cbm = new CallbackManager(src, fs);
            src.PumpNewRGBD(Util.GetImage(0), Util.GetDepth(0));
            Assert.That(fs.Count(), Is.EqualTo(1));
        }

        [Test]
        public void SingleRegisteredCallback()
        {
            var src = new RGBDSourceTestStub();
            var fs = new FrameStoreBase();
            var cbm = new CallbackManager(src, fs);
            //Register for Landmark phase
            var cbLandmark = new CallbackTestStub(cbm, CallbackManager.Priority.FindLandmarks);
            UInt64 lastId;
            for (int i = 1; i < 4; i++)
            {
                lastId = src.PumpNewRGBD(Util.GetImage(i-1), Util.GetDepth(i-1));
                Assert.That(cbLandmark.Count, Is.EqualTo(i));
                Assert.That(cbLandmark.LastId, Is.EqualTo(lastId));
            }
        }

        [Test]
        public void SingleRegisteredCallbackPerPriority()
        {
            var src = new RGBDSourceTestStub();
            var fs = new FrameStoreBase();
            var cbm = new CallbackManager(src, fs);
            UInt64 lastId;
            //Register for Additional priorities
            var cbLandmark = new CallbackTestStub(cbm, CallbackManager.Priority.FindLandmarks);
            var cbPose = new CallbackTestStub(cbm, CallbackManager.Priority.EstimatePose);
            var cbSLAM = new CallbackTestStub(cbm, CallbackManager.Priority.SLAM);
            var cbDisplay = new CallbackTestStub(cbm, CallbackManager.Priority.Display);
            for (int i = 1; i < 4; i++)
            {
                lastId = src.PumpNewRGBD(Util.GetImage(i-1), Util.GetDepth(i-1));
                Assert.That(cbLandmark.Count, Is.EqualTo(i));
                Assert.That(cbLandmark.LastId, Is.EqualTo(lastId));
                Assert.That(cbPose.Count, Is.EqualTo(i));
                Assert.That(cbPose.LastId, Is.EqualTo(lastId));
                Assert.That(cbSLAM.Count, Is.EqualTo(i));
                Assert.That(cbSLAM.LastId, Is.EqualTo(lastId));
                Assert.That(cbDisplay.Count, Is.EqualTo(i));
                Assert.That(cbDisplay.LastId, Is.EqualTo(lastId));
            }
        }
        

    }
}
