// 06. Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN


using System;

class SumOfSeries
{
    static void Main()
    {
        Console.Write("Enter N: ");
        double n = double.Parse(Console.ReadLine());
        Console.Write("Enter X: ");
        double x = double.Parse(Console.ReadLine());

        double nomerator = 1;
        double denomenator = 1;
        double singleResult = 0;
        double totalResult = 0;

        for (double i = n; i >= 1; i--)
        {
            for (double j = 1; j <= i; j++)
            {
                nomerator = nomerator * j;
                denomenator = denomenator * x;
            }
            singleResult = nomerator / denomenator;
            Console.WriteLine("{0}!/{1}^{0} = {2} / {3} = {4}", i, x, nomerator, denomenator, singleResult);
            nomerator = 1;
            denomenator = 1;
            totalResult += singleResult;
        }
        Console.WriteLine("-----------");
        Console.WriteLine("Total Sum: {0}", totalResult + 1);
    }
}