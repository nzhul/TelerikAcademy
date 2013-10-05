using System;
using System.Collections.Generic;

namespace Point
{
    public class Path
    {
        public readonly List<Point3D> AllPoints = new List<Point3D>();

        public void AddPoint(Point3D point)
        {
            this.AllPoints.Add(point);
        }

        public void ClearPath()
        {
            this.AllPoints.Clear();
        }

        public void PrintPath()
        {
            foreach (var point in AllPoints)
            {
                Console.WriteLine("({0}, {1}, {2})", point.X, point.Y, point.Z);
            }
        }
    }
}
