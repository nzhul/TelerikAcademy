// 03. Write a method that returns the last digit of given integer as an English word.
//     Examples: 512  "two", 1024  "four", 12309  "nine".


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
        string[] words = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nice" };
        number %= 10;
        return words[number];
    }
}