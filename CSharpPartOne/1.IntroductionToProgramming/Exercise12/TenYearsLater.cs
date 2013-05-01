// 12. * Write a program to read your age from the console and print how old you will be after 10 years.

using System;

class PrintNumbers
{
    static void Main()
    {
        Console.WriteLine("What is your age ?");
        int age = Convert.ToInt16(Console.ReadLine());
        int futureAge = age + 10;
        Console.WriteLine("After 10 years you will be {0} years old.", futureAge);
    }
}
