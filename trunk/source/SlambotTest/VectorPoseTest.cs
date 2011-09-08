using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit;

using Slambot;

namespace SlambotTest
{
    [TestFixture]
    class VectorPoseTestFixture
    {
        const Double epsilon = 0.0001;

        [Test]
        public void VectorConstructors()
        {
            var v1 = new Vector3();
            Assert.That(v1, Is.Not.Null);
            var v2 = new Vector3(1.0, 2.0, 3.0);
            Assert.That(v2, Is.Not.Null);
        }

        [Test]
        public void VectorAddition()
        {
            var v1 = new Vector3(1.0, 0, 0);
            var v2 = new Vector3(0, 1, 0);
            var v3 = new Vector3(0, 0, 1);
            Vector3 result = v1 + v2 + v3;
            Assert.That(result.X, Is.EqualTo(1.0));
            Assert.That(result.Y, Is.EqualTo(1.0));
            Assert.That(result.Z, Is.EqualTo(1.0));

            Vector3 result2 = v3 + v2 + v1;
            Assert.That(result2, Is.EqualTo(result));

            Vector3 result3 = v2 + v3 + v1;
            Assert.That(result3, Is.EqualTo(result));
        }

        [Test]
        public void VectorSubtraction()
        {
            var v1 = new Vector3(1.0, 0, 0);
            var v2 = new Vector3(0, 1, 0);
            var v3 = new Vector3(0, 0, 1);
            Vector3 result = v1 - v2 - v3;
            Assert.That(result.X, Is.EqualTo(1.0));
            Assert.That(result.Y, Is.EqualTo(-1.0));
            Assert.That(result.Z, Is.EqualTo(-1.0));

            Vector3 result2 = v3 - v2 - v1;
            Assert.That(result2, Is.EqualTo(new Vector3(-1,-1,1)));

            Vector3 result3 = v2 - v3 - v1;
            Assert.That(result3, Is.EqualTo(new Vector3(-1, 1, -1)));

            Vector3 result4 = (v1-v2-v3) + (-v1 + v2 + v3);
            Assert.That(result4, Is.EqualTo(new Vector3(0,0,0)));
        }

        [Test]
        public void VectorMultiply()
        {
            var v1 = new Vector3(1.0, 0, 0);
            var v2 = new Vector3(0, 1, 0);
            var v3 = new Vector3(0, 0, 1);
            Vector3 result = v1 * 0;
            Assert.That(result.X, Is.EqualTo(0));
            Assert.That(result.Y, Is.EqualTo(0));
            Assert.That(result.Z, Is.EqualTo(0));

            Assert.That(v2*2, Is.EqualTo(v2+v2));
            Assert.That(v3*1, Is.EqualTo(v3));
            Assert.That(2*v2, Is.EqualTo(v2+v2));
            Assert.That(1 * v3, Is.EqualTo(v3));
        }

        [Test]
        public void VectorDivision()
        {
            var v1 = new Vector3(1.0, 2, 3);

            Assert.That(v1, Is.EqualTo(v1 / 1));

            Assert.That(((v1 + v1) / 2).X, Is.InRange(v1.X - epsilon, v1.X + epsilon));
            Assert.That(((v1 + v1) / 2).Y, Is.InRange(v1.Y - epsilon, v1.Y + epsilon));
            Assert.That(((v1 + v1) / 2).Z, Is.InRange(v1.Z - epsilon, v1.Z + epsilon));
        }

        [Test]
        public void VectorLength()
        {
            var v1 = new Vector3(1.0, 0, 0);
            var v2 = new Vector3(0, 1, 0);
            var v3 = new Vector3(0, 0, 1);

            Assert.That(1, Is.EqualTo(v1.Length()));
            Assert.That(1, Is.EqualTo(v2.Length()));
            Assert.That(1, Is.EqualTo(v3.Length()));

            Double sqrtOf3 = 1.7320508075688772935274463415059;
            var v4 = new Vector3();
            v4 = v1 + v2 + v3;
            Assert.That((v1 + v2 + v3).Length(), Is.InRange(sqrtOf3 - epsilon, sqrtOf3 + epsilon));
            Assert.That(v4.Length(), Is.InRange(sqrtOf3 - epsilon, sqrtOf3 + epsilon));
            Assert.That((v4+v4).Length(), Is.InRange(2*sqrtOf3 - epsilon, 2*sqrtOf3 + epsilon));
        }

        [Test]
        public void VectorCross()
        {
            var v1 = new Vector3(1.0, 0, 0);
            var v2 = new Vector3(0, 1, 0);
            var v3 = new Vector3(0, 0, 1);

            Assert.That(Vector3.Cross(v1, v2), Is.EqualTo(v3));
        }

        [Test]
        public void VectorDot()
        {
            var v1 = new Vector3(1.0, 0, 0);
            var v2 = new Vector3(0, 1, 0);
            var v3 = new Vector3(0, 0, 1);

            Assert.That(Vector3.Dot(v1, v2), Is.EqualTo(0));
            Assert.That(Vector3.Dot(v2, v3), Is.EqualTo(0));
            Assert.That(Vector3.Dot(v3, v1), Is.EqualTo(0));
        }


    }
}
