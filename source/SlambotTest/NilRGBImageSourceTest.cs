using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit;

using Slambot;

namespace SlambotTest
{
    /// <summary>
    /// At this point, these tests mostly just show that we can indeed write and run unit tests on this project
    /// </summary>
    [TestFixture]
    public class NilRGBImageSourceTest
    {
        private int i;
        private void RGBFunction(System.Drawing.Image rgb, System.Drawing.Image depth)
        {
            i++;
        }

        [Test]
        public void ConstructorWorks()
        {
            var src = new NilRGBImageSource();
            Assert.That(src, Is.Not.Null);
        }

        [Test]
        public void FunctionsCallable()
        {
            var src = new NilRGBImageSource();
            src.SetFrameInterval(1.0);
            i = 0;
            src.RegisterRGBDCallback(RGBFunction);
            Assert.That(i, Is.EqualTo(0));
        }

        /*
        [Test]
        public void ForceTestFailure()
        {
            //Make a test fail so that I can verify that the unit test system is installed correctly
            Assert.That(1, Is.EqualTo(0));
        }
         * */

    }
}
