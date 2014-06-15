using System;

namespace CohesionAndCoupling
{
    // TODO: Point
    class GeometryUtils
    {
        public static double CalcDistance2D(
            double x1, double y1,
            double x2, double y2
        )
        {
            return Math.Sqrt(
                (x2 - x1) * (x2 - x1) +
                (y2 - y1) * (y2 - y1)
            );
        }

        public static double CalcDistance3D(
            double x1, double y1, double z1,
            double x2, double y2, double z2
        )
        {
            return Math.Sqrt(
                (x2 - x1) * (x2 - x1) +
                (y2 - y1) * (y2 - y1) +
                (z2 - z1) * (z2 - z1)
            );
        }
    }
}