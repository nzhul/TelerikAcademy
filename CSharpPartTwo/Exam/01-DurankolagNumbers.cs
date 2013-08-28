using System;
using System.Collections.Generic;

class Durankolag
{
    static void Main()
    {
        string duranKolagNumber = Console.ReadLine();
        List<int> convertedDurankolag = new List<int>();
        List<string> digits = new List<string>();
        GenerateDigits(digits);

        for (int i = 0; i < duranKolagNumber.Length; i++)
        {
            string durDigit = "";
            if (char.IsLower(duranKolagNumber[i]))
            {
                // dobavqme tozi i sledva6tiq char v promenliva i preska4ame 1 simvol
                durDigit = duranKolagNumber.Substring(i, 2);
                i++;
            }
            else
            {
                durDigit = duranKolagNumber[i].ToString();
            }
            convertedDurankolag.Add(digits.IndexOf(durDigit));
        }

        int decimalNumber = 0;
        for (int i = 0, j = convertedDurankolag.Count - 1; i < convertedDurankolag.Count; i++, j--)
        {
            decimalNumber += convertedDurankolag[i] * (int)Math.Pow(168, j);
        }
        Console.WriteLine(decimalNumber);
    }

    private static void GenerateDigits(List<string> digits)
    {
        for (char i = 'A'; i <= 'Z'; i++)
        {
            digits.Add(i.ToString());
        }
        for (char i = 'a'; i <= 'z'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                digits.Add(i.ToString() + j.ToString());
            }
        }
    }
}
