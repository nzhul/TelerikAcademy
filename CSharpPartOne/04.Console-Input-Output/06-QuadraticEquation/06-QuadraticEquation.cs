// 06. Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

using System;

class quadraticEquation
{
    static void Main()
    {
        Console.Write("a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c: ");
        double c = double.Parse(Console.ReadLine());

        double discriminant = (b * b) - (4 * a * c);

        if (discriminant > 0)
        {
            double x1 = (-b + Math.Sqrt(discriminant)) / 2 * a;
            double x2 = (-b - Math.Sqrt(discriminant)) / 2 * a;
            Console.WriteLine("The equation roots are:\nX1: {0}\nX2: {1}", x1, x2);
        }
        else if (discriminant == 0)
        {
            double x1 = -b / (2 * a);
            double x2 = x1;
            Console.WriteLine("The equation roots are:\nX1: {0}\nX2: {1}", x1, x2);
        }
        else if (discriminant < 0)
        {
            Console.WriteLine("This equations doesn't have solution!");
        }

    }
}
