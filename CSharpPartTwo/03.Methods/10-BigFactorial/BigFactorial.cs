using System;
using System.Collections.Generic;
using System.Linq;

class BigFactorial
{
    static void Main()
    {
        Console.Write("Enter the First Number: ");
        byte[] numberOne = Console.ReadLine().ToCharArray().Select(c => byte.Parse(c.ToString())).ToArray();
        Console.Write("Enter the Second Number: ");
        byte[] numberTwo = Console.ReadLine().ToCharArray().Select(c => byte.Parse(c.ToString())).ToArray();

        List<List<byte>> nestedList = Multiply(numberOne, numberTwo);

        for (int i = 0; i < nestedList.Count(); i++)
        {
            for (int j = 0; j < nestedList[i].Count(); j++)
            {
                Console.Write(nestedList[i][j]);
            }
            Console.WriteLine();
        }

        // Трябва да направя метод който да върти цикъл с дължината на последния
    }

    static List<List<byte>> Multiply(byte[] numberOne, byte[] numberTwo)
    {
        byte carry = 0;
        byte product = 0;
        int shift = 0;
        List<List<byte>> rowsForSum = new List<List<byte>>();

        for (int i = numberOne.Length - 1; i >= 0; i--)
        {
            List<byte> sublist = new List<byte>();
            for (int s = 0; s < shift; s++)
            {
                sublist.Add(0);
            }
            for (int j = numberTwo.Length - 1; j >= 0; j--) // moje bi trqbva da vartq na obratno cikala
            {
                product = (byte)(numberOne[i] * numberTwo[j] + carry);
                if (product >= 10)
                {
                    carry = (byte)(product / 10);
                    product %= 10;
                    sublist.Add(product);
                }
                else
                {
                    carry = 0;
                    sublist.Add(product);
                }
            }
            if (carry > 0)
            {
                sublist.Add(carry);
                carry = 0;
            }
            sublist.Reverse();
            rowsForSum.Add(sublist);
            shift++;
        }

        return rowsForSum;

    }
}