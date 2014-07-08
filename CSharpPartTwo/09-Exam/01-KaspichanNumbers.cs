using System;
using System.Collections.Generic;
using System.Numerics;

class Kaspichan
{
    static void Main()
    {
        BigInteger input = BigInteger.Parse(Console.ReadLine());
        List<string> digits = new List<string>();
        List<int> kaspichanNumber = new List<int>();
        GenerateDigits(digits);
        if (input == 0)
        {
            kaspichanNumber.Add(0);
        }
        while (input != 0)
        {
            kaspichanNumber.Add((int)(input % 256));
            input /= 256;
        }
        for (int i = kaspichanNumber.Count - 1; i >= 0; i--)
        {
            Console.Write(digits[kaspichanNumber[i]]);
        }
    }

    private static void GenerateDigits(List<string> digits)
    {
        for (char i = 'A'; i <= 'Z'; i++)
        {
            digits.Add(i.ToString());
        }

        for (char i = 'a'; i <= 'i'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                digits.Add(i.ToString() + j.ToString());
            }
        }
    }
}
