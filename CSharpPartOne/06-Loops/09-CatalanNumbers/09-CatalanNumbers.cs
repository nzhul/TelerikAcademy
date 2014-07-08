// 09. In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:
// (2*n)! / (n + 1)! * n!
// Write a program to calculate the Nth Catalan number by given N.




using System;

class CatalanNumbers
{
    static double Factorial(double n)
    {
        double nFact = 1;
        for (double i = 1; i <= n; i++)
        {
            nFact = nFact * i;
        }
        return nFact;
    }

    static void Main()
    {
        Console.Write("Enter N: ");
        double n = int.Parse(Console.ReadLine());
        double catalanNumber = Factorial(2 * n) / (Factorial(n + 1) * Factorial(n));
        Console.WriteLine("Catalan Number = {0}", catalanNumber);
    }
}

