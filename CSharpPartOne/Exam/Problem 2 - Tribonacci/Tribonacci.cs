using System;
using System.Numerics;

class Fibunacci
{
    static void Main()
    {
        BigInteger firstN = BigInteger.Parse(Console.ReadLine()); ;
        BigInteger secondN = BigInteger.Parse(Console.ReadLine()); ;
        BigInteger thirtN = BigInteger.Parse(Console.ReadLine()); ;
        BigInteger fourtN = 0;
        BigInteger n = BigInteger.Parse(Console.ReadLine()); ;

        for (int i = 3; i < n; i++)
        {
            fourtN = firstN + secondN + thirtN;
            firstN = secondN;
            secondN = thirtN;
            thirtN = fourtN;
        }
        Console.WriteLine(fourtN);
    }
}