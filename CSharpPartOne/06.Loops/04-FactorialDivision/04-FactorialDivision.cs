// 04. Write a program that calculates N!/K! for given N and K (1<K<N).

using System;

class FactorialDivision
{
    static void Main()
    {
        Console.Write("Enter N: ");
        decimal n = decimal.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        decimal k = decimal.Parse(Console.ReadLine());

        decimal result = 1;
        for (decimal i = 0; i < (k - n); i++)
        {
            result = result * (k - i);
        }
        Console.WriteLine("{0}!/{1}! = {2}",n , k, 1 / result);
    }
}