// 01. Write a program that reads a year from the console 
//     and checks whether it is a leap. Use DateTime.


using System;

class DateTimeYear
{
    static void Main()
    {
        Console.Write("Enter an year to check: ");
        int year = int.Parse(Console.ReadLine());

        if (DateTime.IsLeapYear(year))
        {
            Console.WriteLine("The year IS leap!");
        }
        else
        {
            Console.WriteLine("The year ISN'T leap!");
        }
    }
}