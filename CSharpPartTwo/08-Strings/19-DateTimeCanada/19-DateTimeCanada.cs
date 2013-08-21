// 19. Write a program that extracts from a given text all dates that match
//     the format DD.MM.YYYY. Display them in the standard date format for Canada.


using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

class Email
{
    static void Main()
    {
        string text =
@"The war in Europe ended with an invasion of Germany by the Western Allies
and the Soviet Union culminating in the capture of Berlin by Soviet and Polish
troops and the subsequent German unconditional surrender on 08.05.1945. Following
the Potsdam Declaration by the Allies on 26.07.1945, the United States dropped 
atomic bombs on the Japanese cities of Hiroshima and Nagasaki on 06.08.1945 and 09.08.1945 
respectively. With an invasion of the Japanese archipelago imminent, and the Soviet 
Union having declared war on Japan by invading Manchuria, Japan surrendered on 15.08.1945,
ending the war in Asia and cementing the total victory of the Allies over the Axis.
Canadian Recording of a date: 08.15.2012";
        string regex = @"\d{1,2}\.\d{1,2}\.\d{4}";

        MatchCollection datesArray = Regex.Matches(text, regex);
        var provider = new CultureInfo("en-CA", false);

        foreach (Match item in datesArray)
        {
            DateTime date;
            DateTime.TryParse(item.ToString(), out date);
            Console.WriteLine(date.ToString("dd/MM/yyyy", provider));
        }
    }
}