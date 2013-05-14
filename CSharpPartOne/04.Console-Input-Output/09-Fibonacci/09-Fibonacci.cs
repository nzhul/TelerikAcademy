// 09. Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

using System;


class Fibunacci
{
    static void Main()
    {
        decimal firstN = 1;
        decimal secondN = 0;
        decimal thirtN = 0;

        for (int i = 0; i <= 100; i++)
        {
            thirtN = firstN + secondN;
            firstN = secondN;
            secondN = thirtN;
            Console.WriteLine(i + ": "+ thirtN);
        }
    }
}