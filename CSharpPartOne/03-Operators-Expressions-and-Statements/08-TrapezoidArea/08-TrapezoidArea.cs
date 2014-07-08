// 08. Write an expression that calculates trapezoid's area by given sides a and b and height h.

using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.Write("Side a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Side b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Height: ");
        double height = double.Parse(Console.ReadLine());

        double area = ((a + b) / 2) * height;

        Console.WriteLine("The area of the trapezoid is: {0}", area);
    }
}

// We simply use the formula for Surface Area of Trapezoid: ((a + b) / 2) * height