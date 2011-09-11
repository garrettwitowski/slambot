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
    [TestFixture]
    class FrameStoreTest
    {
        //Test functions
        [Test]
        public void ConstructorWorks()
        {
            var fs = new FrameStoreBase();
            Assert.That(fs, Is.Not.Null);
        }

        [Test]
        public void AddImages()
        {
            var fs = new FrameStoreBase();
            //load and add two RGBDs
            UInt64 id;
            var i0 = Util.GetImage(0);
            var d0 = Util.GetDepth(0);
            var i1 = Util.GetImage(1);
            var d1 = Util.GetDepth(1);
            id = fs.OnNewRGBD(i0, d0);
            Assert.That(id, Is.EqualTo(0));
            id = fs.OnNewRGBD(i1, d1);
            Assert.That(id, Is.EqualTo(1));
            //Read them back and verify that they match what we started with
            var image = fs.GetRGB(0);
            var depth = fs.GetDepth(0);
            Assert.That(image, Is.EqualTo(i0));
            Assert.That(depth, Is.EqualTo(d0));
            image = fs.GetRGB(1);
            depth = fs.GetDepth(1);
            Assert.That(image, Is.EqualTo(i1));
            Assert.That(depth, Is.EqualTo(d1));
            //Read out of order to verify that there is no order dependency
            image = fs.GetRGB(0);
            depth = fs.GetDepth(0);
            Assert.That(image, Is.EqualTo(i0));
            Assert.That(depth, Is.EqualTo(d0));
        }

        [Test]
        public void AddAttributes()
        {
            var fs = new FrameStoreBase();
            //Send the first image and add an attribute
            fs.OnNewRGBD(Util.GetImage(0), Util.GetDepth(0));
            fs.GetAttributes(0).Add("key", "image0");
            Assert.That(fs.GetAttributes(0).Count, Is.EqualTo(1));
            //Send the second image, and add an attribute
            fs.OnNewRGBD(Util.GetImage(1), Util.GetDepth(1));
            fs.GetAttributes(1).Add("key", "image1");
            Assert.That(fs.GetAttributes(1).Count, Is.EqualTo(1));
            //Read both keys back and check them
            Assert.That((String)fs.GetAttributes(0)["key"], Is.EqualTo("image0"));
            Assert.That((String)fs.GetAttributes(1)["key"], Is.EqualTo("image1"));
        }
    }
}
