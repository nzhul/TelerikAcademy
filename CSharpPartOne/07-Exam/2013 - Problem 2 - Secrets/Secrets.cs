using System;
using System.Numerics;

class Secrets
{
    static void Main()
    {
        string number = Console.ReadLine().TrimStart('-');
        BigInteger[] digitsArray = new BigInteger[number.Length];
        BigInteger specialSum = 0;
        int position = 1;

        for (int i = 0; i < number.Length; i++)
        {
            digitsArray[i] = int.Parse(number[i].ToString());
        }

        for (int i = digitsArray.Length - 1; i >= 0; i--)
        {
            //Console.WriteLine("Ïndex: {0} - Value: {1}", i, digitsArray[i]);
            if (position % 2 == 0) // Even
            {
                specialSum += (digitsArray[i] * digitsArray[i]) * position;
            }
            else // Odd
            {
                specialSum += digitsArray[i] * (position * position);
            }
            position++;
        }

        string specialSumString = specialSum.ToString();
        BigInteger[] specialSumDigitsArray = new BigInteger[specialSumString.Length];
        for (int i = 0; i < specialSumString.Length; i++)
        {
            specialSumDigitsArray[i] = int.Parse(specialSumString[i].ToString());
        }

        if (specialSumDigitsArray[specialSumDigitsArray.Length - 1] == 0)
        {
            Console.WriteLine(specialSum);
            Console.WriteLine("{0} has no secret alpha-sequence", number);
        }
        else
        {
            BigInteger alphaSequenceLength = specialSumDigitsArray[specialSumDigitsArray.Length - 1];
            int r = (int)(specialSum % 26);
            int letter = 64 + (r + 1);
            Console.WriteLine(specialSum);
            for (int i = 0; i < alphaSequenceLength; i++)
            {
                if (letter > 90)
                {
                    letter -= 26;
                }
                Console.Write((char)letter);
                letter++;
            }
        }
    }
}