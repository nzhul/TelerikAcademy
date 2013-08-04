using System;

class WorkDays
{
    static void Main()
    {
        Console.WriteLine("Enter future date in this format: DD/MM/YYYY:");
        string[] futureDateStr = Console.ReadLine().Split('/');
        CalculateWorkDays(futureDateStr);
    }

    private static void CalculateWorkDays(string[] futureDateStr)
    {
        int day = int.Parse(futureDateStr[0]);
        int month = int.Parse(futureDateStr[1]);
        int year = int.Parse(futureDateStr[2]);

        DateTime startDate = DateTime.Today;
        DateTime futureDate = new DateTime(year, month, day);

        // Simple Validation
        if (futureDate < startDate)
        {
            Console.Write("Please enter FUTURE date!");
            return;
        }

        int totalDays = (futureDate - startDate).Days;
        Console.WriteLine("Total Days: {0}", totalDays);

        // The program calculates correctly the workdays only for furure that
        // that is in the year of 2013.
        // It must be fixed to work for any future year.!
        DateTime[] officialHolidays = 
        {
            new DateTime(2013, 1, 1), // Нова година
            new DateTime(2013, 3, 3), // Ден на Освобождението на България от османско иго
            new DateTime(2013, 5, 3), // (Разпети петък) 
            new DateTime(2013, 5, 4), // (Страстна събота)
            new DateTime(2013, 5, 5), // Великден
            new DateTime(2013, 5, 6), // Великден
            new DateTime(2013, 5, 1), // Ден на труда и на международната работническа солидарност
            new DateTime(2013, 5, 6), // Гергьовден, Ден на храбростта и Българската армия
            new DateTime(2013, 5, 24), // Ден на българската просвета и култура и на славянската писменост
            new DateTime(2013, 9, 6), // Ден на Съединението на България
            new DateTime(2013, 9, 22), // Ден на Независимостта на България
            new DateTime(2013, 11, 1), // Ден на народните будители
            new DateTime(2013, 12, 24), // Бъдни вечер
            new DateTime(2013, 12, 25), // Рождество Христово (Коледа)
            new DateTime(2013, 12, 26) // Рождество Христово (Коледа)
        };

        int workdayCounter = 0;
        bool isHolyday = false;

        for (int i = 0; i < totalDays; i++)
        {
            // Ако не е събота или неделя
            if (!(startDate.DayOfWeek == DayOfWeek.Saturday) && !(startDate.DayOfWeek == DayOfWeek.Sunday))
            {
                // Ако текущия ден не е част равен на някой от официалните празници
                for (int j = 0; j < officialHolidays.Length; j++)
                {
                    if (startDate == officialHolidays[j])
                    {
                        isHolyday = true;
                        break;
                    }
                }
                if (!isHolyday)
                {
                    workdayCounter++;
                }
                isHolyday = false;
            }
            startDate = startDate.AddDays(1);
        }

        Console.WriteLine("Workdays left until {0} : {1}", futureDate, workdayCounter);
    }
}
