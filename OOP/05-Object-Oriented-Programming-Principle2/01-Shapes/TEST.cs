// 01. Define abstract class Shape with only one abstract method CalculateSurface() and fields 
//     width and height. Define two new classes Triangle and Rectangle that implement the virtual
//     method and return the surface of the figure (height*width for rectangle and height*width/2 for 
//     triangle). Define class Circle and suitable constructor so that at initialization height must be kept 
//     equal to width and implement the CalculateSurface() method. Write a program that tests the behavior 
//     of  the CalculateSurface() method for different shapes (Circle, Rectangle, Triangle) stored in an array.


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
