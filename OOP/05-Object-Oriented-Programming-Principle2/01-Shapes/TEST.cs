using System;

namespace Shapes
{
    class TEST
    {
        static void Main()
        {
            Shape[] shapes = 
            {
                new Triangle(2.5, 3.4),
                new Circle(6.4),
                new Rectangle(4.5, 2.1)
            };

            Console.WriteLine("Calculate area of different Shapes:");
            Console.WriteLine(new String('-', 30));
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.Write("{0}: ", shapes[i].GetType().Name);
                double shapeArea = shapes[i].CalculateSurface();
                Console.WriteLine("{0:F2}", shapeArea);
            }
        }
    }
}
