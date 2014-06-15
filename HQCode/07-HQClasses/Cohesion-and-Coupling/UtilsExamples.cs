using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            {
                Console.WriteLine(FileUtils.GetFileExtension("example"));
                Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
                Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

                Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
                Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
                Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));
            }

            {
                Console.WriteLine("Distance in the 2D space = {0:F2}",
                    GeometryUtils.CalcDistance2D(1, -2, 3, 4));

                Console.WriteLine("Distance in the 3D space = {0:F2}",
                    GeometryUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));
            }

            {
                RectangularCuboid rectangularCuboid = new RectangularCuboid()
                {
                    Width = 3,
                    Height = 4,
                    Depth = 5
                };

                Console.WriteLine("Volume = {0:F2}", rectangularCuboid.Volume);

                Console.WriteLine("Diagonal XY = {0:F2}", rectangularCuboid.CalcDiagonalXY());
                Console.WriteLine("Diagonal YZ = {0:F2}", rectangularCuboid.CalcDiagonalYZ());
                Console.WriteLine("Diagonal ZX = {0:F2}", rectangularCuboid.CalcDiagonalZX());

                Console.WriteLine("Diagonal XYZ = {0:F2}", rectangularCuboid.CalcDiagonalXYZ());
            }
        }
    }
}