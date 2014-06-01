using System;

namespace CohesionAndCoupling
{
    class RectangularCuboid
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }

        public double Volume
        {
            get { return this.Width * this.Height * this.Depth; }
        }

        public double CalcDiagonalXY()
        {
            return GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Height);
        }

        public double CalcDiagonalYZ()
        {
            return GeometryUtils.CalcDistance2D(0, 0, this.Height, this.Depth);
        }

        public double CalcDiagonalZX()
        {
            return GeometryUtils.CalcDistance2D(0, 0, this.Depth, this.Width);
        }

        public double CalcDiagonalXYZ()
        {
            return GeometryUtils.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
        }
    }
}