using System;
using System.Linq;
using System.Numerics;

    class OddNumber
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger[] numbers = new BigInteger[n];


            for (int i = 0; i < n; i++)
            {
                numbers[i] = BigInteger.Parse(Console.ReadLine());
            }


            var groups = numbers.GroupBy(v => v);
            foreach (var group in groups)
            {
                if (group.Count() % 2 != 0)
                {
                    Console.WriteLine(group.Key);
                }
            }
        }
    }