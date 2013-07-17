using System;

class ReverseDigits
{
    static void Main()
    {
        string number = Console.ReadLine();
        Console.WriteLine(Reverse(number));
    }

    static int Reverse(string number)
    {
        int[] digits = new int[number.Length];
        int numberInt = int.Parse(number);
        int i = 0;
        while (numberInt > 0)
        {
            int lastDigit = numberInt % 10;
            numberInt /= 10;
            digits[i] = lastDigit;
            i++;
        }

        int finalNumber = 0;
        for (int j = 0; j < digits.Length; j++)
        {
            finalNumber = finalNumber * 10 + digits[j];
        }
        return finalNumber;
    }
}