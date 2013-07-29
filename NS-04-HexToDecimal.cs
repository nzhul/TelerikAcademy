using System;
using System.Linq;

class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Enter Hex Number: ");
        string hexNumber = Console.ReadLine();
        byte[]convertedHex = new byte[hexNumber.Length];

        for (int i = 0; i < convertedHex.Length; i++)
        {
            switch (hexNumber[i])
            {
                case 'A':
                case 'a':
                    convertedHex[i] = 10;
                    break;
                case 'B':
                case 'b':
                    convertedHex[i] = 11;
                    break;
                case 'C':
                case 'c':
                    convertedHex[i] = 12;
                    break;
                case 'D':
                case 'd':
                    convertedHex[i] = 13;
                    break;
                case 'E':
                case 'e':
                    convertedHex[i] = 14;
                    break;
                case 'F':
                case 'f':
                    convertedHex[i] = 15;
                    break;
                default:
                    convertedHex[i] = byte.Parse(Convert.ToString(hexNumber[i]));
                    break;
            }
        }

        int decimalNumber = 0;
        for (int i = 0, j = convertedHex.Length - 1; i < convertedHex.Length; i++, j--)
        {
            decimalNumber += convertedHex[i] * (int)Math.Pow(16, j);
        }
        Console.WriteLine(decimalNumber);
    }
}
