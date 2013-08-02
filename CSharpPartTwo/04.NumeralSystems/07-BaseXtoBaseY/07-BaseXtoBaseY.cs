// 07. Write a program to convert from any numeral system of given 
//     base s to any other numeral system of base d (2 ≤ s, d ≤  16).


using System;
using System.Collections.Generic;

class BaseXtoBaseY
{
    static void Main()
    {
        Console.Write("Enter the base FROM which\nyou wish to convert (2 - 16): ");
        int fromBase = int.Parse(Console.ReadLine());
        Console.Write("Enter the base TO which you\nwish to convert (2 - 16): ");
        int toBase = int.Parse(Console.ReadLine());

        Console.Write("Enter the number: ");
        string input = Console.ReadLine();
        int decimalNumber = XtoDecimal(fromBase, input);
        PrintFinalNumber(DecimalToY(toBase, decimalNumber));

    }

    static int XtoDecimal(int fromBase, string input)
    {
        input = input.ToUpper();
        byte[] convertedInput = new byte[input.Length];

        for (int i = 0; i < convertedInput.Length; i++)
        {
            switch (input[i])
            {
                case 'A':
                    convertedInput[i] = 10;
                    break;
                case 'B':
                    convertedInput[i] = 11;
                    break;
                case 'C':
                    convertedInput[i] = 12;
                    break;
                case 'D':
                    convertedInput[i] = 13;
                    break;
                case 'E':
                    convertedInput[i] = 14;
                    break;
                case 'F':
                    convertedInput[i] = 15;
                    break;
                default:
                    convertedInput[i] = byte.Parse(Convert.ToString(input[i]));
                    break;
            }
        }
        int decimalNumber = 0;
        for (int i = 0, j = convertedInput.Length - 1; i < convertedInput.Length; i++, j--)
        {
            decimalNumber += convertedInput[i] * (int)Math.Pow(fromBase, j);
        }
        return decimalNumber;
    }

    static List<byte> DecimalToY(int toBase, int decimalNumber)
    {
        List<byte> finalNumber = new List<byte>();

        while (decimalNumber != 0)
        {
            finalNumber.Add((byte)(decimalNumber % toBase));
            decimalNumber /= toBase;
        }
        return finalNumber;
    }

    static void PrintFinalNumber(List<byte> finalNumber)
    {
        for (int i = finalNumber.Count - 1; i >= 0; i--)
        {
            switch (finalNumber[i])
            {
                case 10:
                    Console.Write('A');
                    break;
                case 11:
                    Console.Write('B');
                    break;
                case 12:
                    Console.Write('C');
                    break;
                case 13:
                    Console.Write('D');
                    break;
                case 14:
                    Console.Write('E');
                    break;
                case 15:
                    Console.Write('F');
                    break;
                default:
                    Console.Write(finalNumber[i]);
                    break;
            }
        }
    }
}