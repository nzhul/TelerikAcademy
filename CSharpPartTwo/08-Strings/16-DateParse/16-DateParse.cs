// 16. Write a program that reads two dates in the format: day.month.year 
//     and calculates the number of days between them. Example:

//     Enter the first date: 27.02.2006
//     Enter the second date: 3.03.2004
//     Distance: 4 days

using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter First date: ");
            string firstInput = Console.ReadLine();
            Console.Write("Enter Second date: ");
            string secondInput = Console.ReadLine();
            DateTime firstDate;
            DateTime secondDate;
            DateTime.TryParse(firstInput, out firstDate);
            DateTime.TryParse(secondInput, out secondDate);

            if (firstDate == DateTime.MinValue || secondDate == DateTime.MinValue)
            {
                Console.WriteLine("Please Enter Valid Date: ");
                continue;
            }
            else
            {
                TimeSpan time = firstDate - secondDate;
                Console.WriteLine("Days: {0}", Math.Abs(time.Days));
                return;
            }
        }
    }
}