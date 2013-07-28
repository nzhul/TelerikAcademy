using System;
using System.Collections.Generic;


class DecimalToHex
{
    static void Main()
    {
        Console.Write("Decimal: ");
        int n = int.Parse(Console.ReadLine());
        List<byte> hexNumber = new List<byte>();

        while (n != 0)
        {
            hexNumber.Add((byte)(n % 16));
            n /= 16;
        }
        Console.Write("Hexadecimal: ", n);
        for (int i = hexNumber.Count - 1; i >= 0; i--)
        {
            switch (hexNumber[i])
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
                    Console.Write(hexNumber[i]);
                    break;
            }
        }
        Console.WriteLine();
    }
}
