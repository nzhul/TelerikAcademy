using System;

namespace Shapes
{
    public abstract class Shape
    {
        // Properties
        private double width;
        private double height;

        // Fields
        public double Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        // Constructors
        protected Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        // Abstract Methods
        public abstract double CalculateSurface();

    }
}
