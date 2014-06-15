using System;

namespace Shapes
{
    public class Triangle : Shape
    {
        // Constructor
        public Triangle(double width, double height)
            : base(width, height)
        { }

        // Abstract Method CalculateSurface implementation
        public override double CalculateSurface()
        {
            return this.Width * this.Height / 2;
        }
    }
}
