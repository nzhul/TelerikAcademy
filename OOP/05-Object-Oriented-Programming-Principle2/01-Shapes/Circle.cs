using System;

namespace Shapes
{
    public class Circle : Shape
    {
        // Constructor
        public Circle(double radius)
            : base(radius * 2, radius * 2)
        { }

        // Abstract method CalculateSurface() Override
        public override double CalculateSurface()
        {
            return 2 * Math.PI * this.Height;
        }
    }
}
