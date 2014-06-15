// 06. Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

using System;

class withinACircle
{
    static void Main()
    {
        Console.WriteLine("Please enter the coordinates X & Y coordinates:");

        Console.Write("X: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("Y: ");
        double y = double.Parse(Console.ReadLine());
        Console.Write("Circle radius: "); // Please enter 5 for circle with radius of 5
        double circleRadius = double.Parse(Console.ReadLine()); ;

        if ((x * x + y * y) <= (circleRadius * circleRadius))
        {
            Console.WriteLine("The given point IS within a circle with radius if {0}!", circleRadius);
        }
        else
        {
            Console.WriteLine("The given point IS NOT within a circle with radius if {0}!", circleRadius);
        }
    }
}
