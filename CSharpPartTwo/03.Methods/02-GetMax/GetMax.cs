// 02. Write a method GetMax() with two parameters that returns the bigger of two integers.
// Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().


using System;

class GetMaxMethod
{
    static void Main()
    {
        Console.Write("Enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter c: ");
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine("The maximum number is: {0}", GetMax(GetMax(a, b), c));
    }

    static int GetMax(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
}