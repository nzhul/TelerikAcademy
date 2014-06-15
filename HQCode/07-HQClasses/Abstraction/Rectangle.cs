using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private double width = 0;
        public double Width
        {
            get { return this.width; }
            private set
            {
                this.PositiveExceptionHelper(value, "width");

                this.width = value;
            }
        }

        private double height = 0;
        public double Height
        {
            get { return this.height; }
            private set
            {
                this.PositiveExceptionHelper(value, "height");

                this.height = value;
            }
        }

        public override double Perimeter
        {
            get { return 2 * (this.Width + this.Height); }
        }

        public override double Area
        {
            get { return this.Width * this.Height; }
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}