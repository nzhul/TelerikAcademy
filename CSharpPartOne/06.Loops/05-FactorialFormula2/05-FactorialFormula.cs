// 05. Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

using System;

class FactorialFormula
{
    static void Main()
    {
        Console.Write("Enter N: ");
        decimal n = decimal.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        decimal k = decimal.Parse(Console.ReadLine());

        // N!*K! / (K-N)! = N! * (K - (K - N))
        decimal nFact = 1;
        for (decimal i = 1; i <= n; i++)
        {
            nFact = nFact * i;
        }

        decimal resultRight = 1;
        for (decimal i = 0; i < (k - (k - n)); i++)
        {
            resultRight = resultRight * (k - i);
        }

        Console.WriteLine(nFact * resultRight);
    }
}

// Example:
// N = 5 and K = 8
//
// 1 * 2 * 3 * 4 * 5   *   1 * 2 * 3 * * 4 * 5 * 6 * 7 *8
// ------------------------------------------------------ 
//                     1 * 2 * 3

// 1 * 2 * 3 * 4 * 5   *   4 * 5 * 6 * 7 * 8
// -----------------------------------------
//                     1

// 120 * 6720
// 80640