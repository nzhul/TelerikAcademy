// 02. Write a program to convert binary numbers to their decimal representation.


using System;
using System.Linq;

class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Enter binary Number: ");
        byte[] binaryNumber = Console.ReadLine().ToCharArray().Select(c => byte.Parse(c.ToString())).ToArray();

        int decimalNumber = 0;
        for (int i = 0, j = binaryNumber.Length - 1; i < binaryNumber.Length; i++, j--)
        {
            decimalNumber += binaryNumber[i] * (int)Math.Pow(2, j);
        }
        Console.WriteLine(decimalNumber);
    }
}