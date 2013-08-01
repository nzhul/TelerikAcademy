using System;
using System.Collections.Generic;

class SignedShort
{
    static void Main()
    {
        Console.Write("Enter 16-bit (short) number: ");
        int input = int.Parse(Console.ReadLine());
        string finalNumber = "";

        List<int> digits = new List<int>();

        if (input >= 0)
        {
            while (input != 0)
            {
                digits.Add(input % 2);
                input /= 2;
            }

            digits.Reverse();

            for (int i = 0; i < digits.Count; i++)
            {
                finalNumber += digits[i];
            }

            while (finalNumber.Length % 16 != 0)
            {
                finalNumber = "0" + finalNumber;
            }
        }
        else
        {
            input = Math.Abs(input) - 1;

            while (input != 0)
            {
                digits.Add(input % 2);
                input /= 2;
            }

            digits.Reverse();

            for (int i = 0; i < digits.Count; i++)
            {
                if (digits[i] == 0)
                {
                    finalNumber += "1";
                }
                else
                {
                    finalNumber += "0";
                }
            }

            while (finalNumber.Length % 16 != 0)
            {
                finalNumber = "1" + finalNumber;
            }
        }
        Console.Write("Binary: ");
        Console.WriteLine(finalNumber);
    }
}
