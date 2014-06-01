using System;

namespace Abstraction
{
    class FigureExamples
    {
        static void Main()
        {
            Console.WriteLine(new Rectangle(2, 3));
            Console.WriteLine(new Circle(5));

            try
            {
                new Rectangle(-1, 1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                new Rectangle(1, -1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                new Circle(-1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}