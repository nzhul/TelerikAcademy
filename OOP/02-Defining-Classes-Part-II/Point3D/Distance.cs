using System;

namespace Point
{
    static class Distance
    {
        public static double EucledeanDistance(Point3D a, Point3D b)
        {
            double distance = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.Z - b.Z, 2));
            return distance;
        }
    }
}
