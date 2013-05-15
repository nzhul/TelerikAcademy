// 03. Write a program that finds the biggest of three integers using nested if statements.

using System;
using System.Linq;

class ProductSign
{
    static void Main()
    {
        int a = 1;
        int b = 2;
        int c = 3;

        if ((a >= b && a >= c))
        {
            Console.WriteLine("{0} is the biggest integer.", a);
        }
        else if (b >= a && b >= c)
        {
            Console.WriteLine("{0} is the biggest integer.", b);
        }
        else
        {
            Console.WriteLine("{0} is the biggest integer.", c);
        }

        // Secondary solution
        int[] numbers = new int[] { 1, 3, 2 };
        int maximumNumber = numbers.Max();
        Console.WriteLine("the Maximum number is: {0}",maximumNumber);
    }
}
