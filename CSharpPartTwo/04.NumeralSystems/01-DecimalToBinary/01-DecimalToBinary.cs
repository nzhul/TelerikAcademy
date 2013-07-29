// 01. Write a program to convert decimal numbers to their binary representation.

using System;
using System.Collections.Generic;


class DecimalToBinary
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        List<bool> binaryNumber = new List<bool>();

        while (n != 0)
        {
            if (n % 2 == 0)
            {
                binaryNumber.Add(false);
            }
            else
            {
                binaryNumber.Add(true);
            }
            n /= 2;
        }
        for (int i = binaryNumber.Count - 1; i >= 0; i--)
        {
            if (binaryNumber[i])
            {
                Console.Write(1);
            }
            else
            {
                Console.Write(0);
            }
        }
    }
}