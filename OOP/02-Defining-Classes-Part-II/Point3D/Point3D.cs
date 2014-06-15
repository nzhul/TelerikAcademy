using System;

namespace Point
{
    public struct Point3D
    {
        private static readonly Point3D basePoint = new Point3D(0, 0, 0);

        // Fields
        private double x;
        private double y;
        private double z;

        // Properties
        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public static Point3D BasePoint
        {
            get { return basePoint; }
        }

        // Constructor
        public Point3D(double x, double y, double z)
            : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // ToString OverRide
        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})", this.x, this.y, this.z);
        }
    }
}
