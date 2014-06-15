using System;

namespace Point
{
    class PointTest
    {
        static void Main()
        {
            //Printing BasePoint
            Console.Write("Starting Point: ");
            Console.WriteLine(Point3D.BasePoint);

            // Testing EucledeanDistance
            Point3D randomPoint = new Point3D(2.65, 4.56, 8.26);
            double distance = Distance.EucledeanDistance(Point3D.BasePoint, randomPoint);
            Console.WriteLine("Distance between {0} and {1} = {2:F2}", Point3D.BasePoint, randomPoint, distance);

            // Testing Path storage
            // Uncomment this code to test Path Saving
            //Path testPath = new Path();
            //testPath.AddPoint(Point3D.BasePoint);
            //testPath.AddPoint(randomPoint);
            //testPath.AddPoint(new Point3D(4.3, -2.2, 6.25));

            //PathStorage.SavePath(testPath);

            Console.WriteLine(new String('-', 30));
            Console.WriteLine("Printing Loaded Path:");
            Path loadedPath = PathStorage.LoadPath();
            loadedPath.PrintPath();

        }
    }
}
