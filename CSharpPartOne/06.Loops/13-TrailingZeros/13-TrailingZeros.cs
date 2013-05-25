// 13. * Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
//	N = 10  N! = 3628800  2
//	N = 20  N! = 2432902008176640000  4
//	Does your program work for N = 50 000?
//	Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!





using System;
using System.Numerics;

class TrailingZeros
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger nFact = 1; // I Use BigInteger Only for Comparison purpoise and not for solving the problem!!!
        for (int i = 1; i <= n; i++)
        {
            nFact = nFact * i;
        }

        Console.WriteLine("{0}! = {1}", n, nFact);

        int zeroCounter = 0;

        while (true)
        {
            int result = n / 5;
            if (result != 0)
            {
                zeroCounter = zeroCounter + result;
                n = result;
            }
            else
            {
                Console.WriteLine("Trailing zeros count: {0}", zeroCounter);
                break;
            }
        }
    }
}

// 45:5=9, 9:5=1, значи 9+1=10 нули