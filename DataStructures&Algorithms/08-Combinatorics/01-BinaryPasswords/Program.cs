namespace BinaryPasswords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;
    class Program
    {
        static void Main()
        {
            string line = Console.ReadLine();
            BigInteger counter = 0;

            if (String.IsNullOrEmpty(line))
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '*')
                {
                    counter++;
                }
            }

            BigInteger combinations = (BigInteger)Math.Pow(2, (ulong)counter);
            Console.WriteLine(combinations);

        }
    }
}
