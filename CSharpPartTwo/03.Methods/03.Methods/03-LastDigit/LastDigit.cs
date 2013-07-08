using System;

class LastDigit
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}", GetLastDigit(number));
    }

    static string GetLastDigit(int number)
    {
        string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nice" };
        number %= 10;
        return words[number];
    }
}