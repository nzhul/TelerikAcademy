using System;

namespace Abstraction
{
    class Circle : Figure
    {
        private double radius = 0;
        public double Radius
        {
            get { return this.radius; }
            private set
            {
                this.PositiveExceptionHelper(value, "radius");

                this.radius = value;
            }
        }

        public override double Perimeter
        {
            get { return 2 * Math.PI * this.Radius; }
        }

        public override double Area
        {
            get { return Math.PI * this.Radius * this.Radius; }
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }
    }
}