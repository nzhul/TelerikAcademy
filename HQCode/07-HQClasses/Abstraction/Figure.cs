using System;
using System.Collections.Generic;

namespace Abstraction
{
    abstract class Figure : IFigure
    {
        public abstract double Perimeter { get; }
        public abstract double Area { get; }

        protected void PositiveExceptionHelper(double value, string property)
        {
            if (!(value > 0))
                throw new ArgumentOutOfRangeException(property, "Value must be positive.");
        }

        public override string ToString()
        {
            List<string> info = new List<string>();

            info.Add(String.Format("I am a {0}.", this.GetType().Name));
            info.Add(String.Format("My perimeter is {0:F2}.", this.Perimeter));
            info.Add(String.Format("My surface is {0:F2}.", this.Area));

            return String.Join(" ", info);
        }
    }
}