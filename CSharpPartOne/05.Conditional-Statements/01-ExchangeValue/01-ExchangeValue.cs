// 01. Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.

using System;

class ExchangeValue
{
    static void Main()
    {
        Console.Write("Enter value for a:");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter value for b:");
        int b = int.Parse(Console.ReadLine());
        int c;
        Console.WriteLine("Original Values: a = {0}; b = {1}", a, b);

        if (a > b)
        {
            c = a;
            a = b;
            b = c;
        }
        Console.WriteLine("Exchanged Values: a = {0}; b = {1}", a, b);
    }
}
