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
    //Actual Tests
    [TestFixture]
    class LandmarkTest
    {
        //Test functions
        [Test]
        public void ConstructorWorks()
        {
            var src = new RGBDSourceTestStub();
            var fs = new FrameStoreBase();
            var cbm = new CallbackManager(src, fs);
            var lm = new LandmarkIdentifierBase(cbm);
            Assert.That(lm, Is.Not.Null);
        }

        [Test]
        public void FindLandmarkListKeyInFrameStore()
        {
            var src = new RGBDSourceTestStub();
            var fs = new FrameStoreBase();
            var cbm = new CallbackManager(src, fs);
            var lm = new LandmarkIdentifierBase(cbm);
            //Pump one image through, then verify that we got some landmarks and the landmark list for that image
            UInt64 lastId;
            lastId = src.PumpNewRGBD(Util.GetImage(0), Util.GetDepth(0));
            //Is Landmark list valid?
            var llkString = (List<String>)fs.GetConfig()["Landmarks"];
            Assert.That(llkString, Is.Not.Empty);
            Assert.That(llkString[0], Is.StringMatching("BaseLandmarks"));
            //Are there actual landmarks?
            var landmarks = (List<Landmark>)fs.GetAttributes(lastId)[llkString[0]];
            Assert.That(landmarks, Is.Not.Empty);
        }

    }
}
