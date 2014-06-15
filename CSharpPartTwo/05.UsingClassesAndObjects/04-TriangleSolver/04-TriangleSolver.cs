// 04. Write methods that calculate the surface of a triangle by given:
//     Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math

using System;
using System.Globalization;

 
class TriangleSurface
{
    static void Main()
    {
        CultureInfo invC = CultureInfo.InvariantCulture;
        Console.WriteLine("Choose your way to calculate the area:");
        Console.Write("\u250c");
        Console.Write("------------------------------");
        Console.WriteLine("\u2510");
        Console.WriteLine("| 1. Side and Altitude         |");
        Console.WriteLine("| 2. Three Sides (Heron)       |");
        Console.WriteLine("| 3. Two Sides And Angle (SAS) |");
        Console.Write("\u2514");
        Console.Write("------------------------------");
        Console.WriteLine("\u2518");

        int input = int.Parse(Console.ReadLine());

        switch (input)
        {
            case 1:
                SideAndAltitude();
                break;
            case 2:
                Heron();
                break;
            case 3:
                SAS();
                break;
            default:
                Console.WriteLine("Invalid Input - Please Select 1, 2 or 3");
                break;
        }
    }

    private static void SAS()
    {
        // Formula: SAS or "Side angle Side" Method
        // S = (a * b * sin(C)) / 2
        // Where a and b are sides and C is the angle between them
        Console.WriteLine("Enter side 'a': ");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter side 'b': ");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter Angle 'C' in Degree: ");
        double c = double.Parse(Console.ReadLine());
        // Math.Sin accepts the angle value in radians - so if we want to input degrees
        // we must convert the degree value to radian value with the following formula:
        // Convertion formula: Radians = (Degree * (PI / 180)).
        double angleInRadians = c * Math.PI / 180;
        double S = (a * b * Math.Sin(angleInRadians)) / 2;
        Console.WriteLine("S = {0}", S);
    }

    private static void Heron()
    {
        // Formula: : S=sqrt{p(p-a)(p-b)(p-c)}
        // p = Perimeter / 2
        Console.Write("Enter side 'a': ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter side 'b': ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter side 'c': ");
        double c = double.Parse(Console.ReadLine());
        double Perimeter = a + b + c;
        double p = Perimeter / 2;
        double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        Console.WriteLine("S = {0}", S);
    }

    private static void SideAndAltitude()
    {
        // Formula: (a * h) / 2
        Console.Write("Enter Side 'a': ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter altitude 'h': ");
        double h = double.Parse(Console.ReadLine());
        Console.WriteLine("S = {0}", (a * h) / 2);
    }
}