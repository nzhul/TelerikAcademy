// 06. Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;
using System.Text;

class BinaryToHex
{
    static void Main()
    {
        Console.Write("Enter Binary Number: ");
        string binaryNumber = Console.ReadLine();

        // Solves the problem when the number of digits is 
        // not divisible by 4 - by adding Leading Zeros
        for (int i = 4; i < 32; i *= 4)
        {
            if (binaryNumber.Length < i)
            {
                string leadingZeros = new String('0', i - binaryNumber.Length);
                binaryNumber = leadingZeros + binaryNumber;
                break;
            }
        }

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < binaryNumber.Length; i = i + 4)
        {
            StringBuilder currentDigit = new StringBuilder();
            for (int j = i; j < i + 4; j++)
            {
                currentDigit.Append(binaryNumber[j]);
            }
            string finalDigit = currentDigit.ToString();
            switch (finalDigit)
            {
                case "0000": result.Append('0'); break;
                case "0001": result.Append('1'); break;
                case "0010": result.Append('2'); break;
                case "0011": result.Append('3'); break;
                case "0100": result.Append('4'); break;
                case "0101": result.Append('5'); break;
                case "0110": result.Append('6'); break;
                case "0111": result.Append('7'); break;
                case "1000": result.Append('8'); break;
                case "1001": result.Append('9'); break;
                case "1010": result.Append('A'); break;
                case "1011": result.Append('B'); break;
                case "1100": result.Append('C'); break;
                case "1101": result.Append('D'); break;
                case "1110": result.Append('E'); break;
                case "1111": result.Append('F'); break;
                default:
                    break;
            }
        }
        // TrimStart removes the zeros in front of the binary number
        string finalBit = result.ToString().TrimStart('0');
        Console.WriteLine(finalBit);
    }
}