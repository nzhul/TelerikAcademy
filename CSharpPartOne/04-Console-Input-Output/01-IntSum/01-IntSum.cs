// 01. Write a program that reads 3 integer numbers from the console and prints their sum.

using System;

class IntSum
{
    static void Main()
    {
        Console.Write("Number a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Number b: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Number c: ");
        int c = int.Parse(Console.ReadLine());

        int sum = a + b + c;

        Console.WriteLine("The sum of numbers a, b & c is: {0}", sum);
    }
}
