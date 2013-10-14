// 06. Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
//     Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.


using System;
using System.Linq;

class SelectNumbersLambda
{
    static void Main()
    {
        int[] numbers = new int[100];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i;
        }

        Console.WriteLine("Selection with Lambda:");
        var selectedNumbers = numbers.Where(x => x % 21 == 0);
        foreach (var number in selectedNumbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nSelection with LINQ:");
        var selectedNumbersLINQ = from number in numbers
                                  where number % 21 == 0
                                  select number;
        foreach (var number in selectedNumbersLINQ)
        {
            Console.WriteLine(number);
        }
    }
}
