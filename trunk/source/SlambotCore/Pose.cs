using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;


namespace Slambot
{
        // Looks useful but doesn't exactly solve our problems: http://msdn.microsoft.com/en-us/library/bb196414.aspx#ID4EUC
        //  Vector3: http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.vector3_members.aspx
        // Notes:
        //  1) you need XNA to get access to the Vector3 struct, which is really a pretty basic struct (I make just make one)
        //  2) the matricxis XYZ location, XYZ look at, and XYZ up.  I'm pretty sure this is what OpenGL does too, so we should follow suit

    /// <summary>
    /// 3D Vector with basic geometry functions
    /// </summary>
    public struct Vector3
    {
        // Vector Components
        public Double X { get; set;}
        public Double Y { get; set;}
        public Double Z { get; set;}

        // Constructors
        public Vector3(Double X, Double Y, Double Z):this() { this.X = X; this.Y = Y; this.Z = Z; }
        public Vector3(Vector3 orig) : this() { this.X = orig.X; this.Y = orig.Y; this.Z = orig.Z; }

        // Basic Math Operations
        public static Vector3 operator +(Vector3 a, Vector3 b) 
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y -  b.Y, a.Z - b.Z);
        }

        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(-a.X, -a.Y, -a.Z);
        }

        public static Vector3 operator *(Vector3 a, Double scaleFactor)
        {
            return new Vector3(a.X * scaleFactor, a.Y * scaleFactor, a.Z * scaleFactor);
        }

        public static Vector3 operator *(Double scaleFactor, Vector3 a)
        {
            return new Vector3(a.X * scaleFactor, a.Y * scaleFactor, a.Z * scaleFactor);
        }

        public static Vector3 operator /(Vector3 a, Double divFactor)
        {
            return new Vector3(a.X / divFactor, a.Y / divFactor, a.Z / divFactor);
        }

        public String ToString()
        {
            return "["+X+","+Y+","+Z+"]";
        }



        /// <summary>
        /// Length of the vector
        /// </summary>
        /// <returns>length of the vector</returns>
        public Double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        /// <summary>
        /// Normal of the vector
        /// </summary>
        /// <returns>a normal vector</returns>
        public Vector3 Normalize()
        {
            Double l = this.Length();
            return new Vector3(X / l, Y / l, Z / l);
        }

        /// <summary>
        /// Dot product of two vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Dot product</returns>
        public static Double Dot(Vector3 a, Vector3 b)
        {
            //throw new NotImplementedException("TODO: implement Vector3::Dot()");
            double x1 = a.X;
            double y1 = a.Y;
            double z1 = a.Z;
            double x2 = b.X;
            double y2 = b.Y;
            double z2 = b.Z;
            double dotP = x1 * x2 + y1 * y2 + z1 * z2;
            return dotP;
        }

        /// <summary>
        /// Cross product of two vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Cross product</returns>
        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            //throw new NotImplementedException("TODO: implement Vector3::Cross()");
            double x1 = a.X;
            double y1 = a.Y;
            double z1 = a.Z;
            double x2 = b.X;
            double y2 = b.Y;
            double z2 = b.Z;
            double [,] theVectors = new double [3,3] {{1, 1, 1},
                                                      {x1,y1,z1},
                                                      {x2,y2,z2}};
            double resultX = theVectors[0, 0] * (theVectors[1, 1] * theVectors[2, 2] - theVectors[2, 1] * theVectors[1, 2]);
            double resultY = theVectors[0, 1] * (theVectors[1, 0] * theVectors[2, 2] - theVectors[2, 0] * theVectors[1, 2]);
            double resultZ = theVectors[0, 2] * (theVectors[1, 0] * theVectors[2, 1] - theVectors[2, 0] * theVectors[1, 1]);
            Vector3 result = new Vector3(resultX, -resultY, resultZ);
            return result;
        }
    }


    /// <summary>
    /// Pose of the robot includes position, direction, and rotations.  Similar to a view matrix in XNA.
    /// </summary>
    struct Pose
    {
        Vector3 Position {get; set;}
        Vector3 LookAt   {get; set;}
        Vector3 Up       {get; set;}
        //TODO: Pose() & Vector3() constructor!
        Pose(Vector3 Position, Vector3 LookAt, Vector3 Up):this(){ this.Position = Position; this.LookAt = LookAt; this.Up = Up; }
        Pose(Pose orig):this() { this.Position = orig.Position; this.LookAt = orig.LookAt; this.Up = orig.Up; }

        /// <summary>
        /// From the current pose, go to the next pose.  This allows each pose to be in the relative coordinate system of
        /// the previous pose, but by Following we can reduce a series of relative poses back into the original coordinate
        /// system of the first pose.
        /// </summary>
        /// <param name="next">Next pose</param>
        /// <returns>Next pose, in the coordinate system of the first pose</returns>
        Pose Follow(Pose next)
        {
            throw new NotImplementedException("TODO: implement Pose::Follow()");
        }
    }


}
