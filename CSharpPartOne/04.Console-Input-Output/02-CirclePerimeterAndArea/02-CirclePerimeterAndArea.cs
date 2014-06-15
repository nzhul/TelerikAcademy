// 02. Write a program that reads the radius r of a circle and prints its perimeter and area.

using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.Write("Please enter the circle radius: ");
        double radius = double.Parse(Console.ReadLine());

        double perimeter = 2 * Math.PI * radius;
        double area = Math.PI * radius * radius;

        Console.WriteLine("Circle Radius: {0} \nCircle Perimeter: {1}\nCircle Area: {2}", radius, perimeter, area);
    }
}
