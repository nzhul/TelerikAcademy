// 06. Write a program that enters the coefficients a, b and c of a quadratic equation a*x2 + b*x + c = 0
//     and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.


using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.Write("a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c: ");
        double c = double.Parse(Console.ReadLine());

        if (a == 0)
        {
            Console.WriteLine("This is not an quadratic equation!");
        }
        else
        {
            double discriminant = (b * b) - (4 * a * c);
            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine("The equation roots are:\nX1: {0}\nX2: {1}", x1, x2);
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("The equaltion has only one root: {0}", x);
            }
            else if (discriminant < 0)
            {
                Console.WriteLine("This equations doesn't have solution!");
            }
        }
    }
}

// First we find the discriminant of the quadratic equation and then
// depending on the discriminant value we solve the quadric equation
// using the well known formula: x1 = (-b + Math.Sqrt((b * b) - (4 * a * c))) / (2 * a) and x2 = (-b - Math.Sqrt((b * b) - (4 * a * c))) / (2 * a)