// 02. Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

using System;

class DivideByFiveAndSeven
{
    static void Main()
    {
        Console.WriteLine("Please enter a number to check if it can be divided by 5 and 7 at the same time.");
        int number = int.Parse(Console.ReadLine());

        if ((number % 5 == 0) && (number % 7 == 0))
        {
            Console.WriteLine("The number CAN be divided by 5 and 7 at the same time!");
        }
        else
        {
            Console.WriteLine("The number CANNOT be divided by 5 and 7 at the same time!");
        }
    }
}

