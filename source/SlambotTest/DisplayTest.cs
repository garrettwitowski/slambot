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
    class DisplayTest
    {
        //Test functions
        [Test]
        public void ConstructorWorks()
        {
            //This is the typical setup for a Slambot system:
            //  a series of constructors chained together around the callback manager
            var src = new RGBDSourceTestStub();
            var fs = new FrameStoreBase();
            var cbm = new CallbackManager(src, fs);
            var lm = new LandmarkIdentifierBase(cbm);
            var display = new DisplayBase(cbm);
            Assert.That(display, Is.Not.Null);
        }

        //There isn't much more to test because there isn't much more this class does
    }
}
