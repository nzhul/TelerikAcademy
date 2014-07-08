// 05. Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.

using System;

class GreaterNumber
{
    static void Main()
    {
        Console.Write("Number a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Number b: ");
        int b = int.Parse(Console.ReadLine());

        int max = Math.Max(a, b);

        Console.WriteLine("The Greater number is {0}",max);

    }
}
