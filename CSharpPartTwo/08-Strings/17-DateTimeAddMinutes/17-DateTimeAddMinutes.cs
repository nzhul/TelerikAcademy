// 17. Write a program that reads a date and time given in the format: day.month.year 
//     hour:minute:second and prints the date and time after 6 hours and 30 minutes 
//     (in the same format) along with the day of week in Bulgarian.


using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter Date in the following format:\n(day.month.year hour:minute:second) ");
            string dateInput = Console.ReadLine();
            DateTime date;
            DateTime.TryParse(dateInput, out date);
            if (date == DateTime.MinValue)
            {
                Console.WriteLine("Invalid Date!");
            }
            else
            {
                Console.WriteLine(date.AddMinutes(6 * 60 + 30));
                return;
            }
        }
    }
}