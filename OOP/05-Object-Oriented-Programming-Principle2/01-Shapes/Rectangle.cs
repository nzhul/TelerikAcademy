using System;

namespace Shapes
{
    public class Rectangle : Shape
    {
        // Constructor
        public Rectangle(double width, double heigth)
            : base(width, heigth)
        { }

        // Abstract method CalculateSurface Impplementation
        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
