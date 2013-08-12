// 02. Write a method ReadNumber(int start, int end) that enters an integer 
//     number in given range [start…end]. If an invalid number or non-number 
//     text is entered, the method should throw an exception. Using this method 
//     write a program that enters 10 numbers:
//            a1, a2, … a10, such that 1 < a1 < … < a10 < 100


using System;
using System.Collections.Generic;

class ReadNumberClass
{
    static void Main()
    {
        int numbersCount = 3;
        int start = 1;
        int end = 100;
        List<int> array = new List<int>();

        for (int i = 0; i < numbersCount; i++)
        {
            array.Add(ReadNumber(start, end));
        }

        // Printing the collected numbers - Just for test
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }

    static int ReadNumber(int start, int end)
    {
        Console.Write("Enter number in the range [1, 100]: ");
        int n = int.Parse(Console.ReadLine());
        try
        {
            if (n <= start || n >= end)
            {
                throw new ArgumentOutOfRangeException();
            }
            Console.WriteLine("Valid number!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("The number is not in range [1, 100]");
        }
        catch (FormatException)
        {
            Console.WriteLine("The input is not a number!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number is too BIG!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("You have entered nothing");
        }
        return n;
    }
}