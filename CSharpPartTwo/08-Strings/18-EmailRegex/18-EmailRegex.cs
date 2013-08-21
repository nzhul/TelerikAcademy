// 18. Write a program for extracting all email addresses from given text. 
//     All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.


using System;
using System.Linq;
using System.Text.RegularExpressions;

class Email
{
    static void Main()
    {
        string text =
@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
Fusce viverra, erat nec volutpat convallis, lectus arcu interdum 
justo, in suscipit lacus dolor at ante. Quisque quis lacus arcu.
Pellentesque Impad1945@superrito.com consectetur elementum sem Broure256@armyspy.com, sed vehicula sapien. Aliquam
fermentum pellentesque urna at egestas. Morbi eu dui auctor, fermentum ZThaters32@rhyta.com
nulla nec, posuere lacus. Curabitur nisl sem, semper eu vehicula ut,
pharetra a nisl. Vestibulum RArly1960@gustr.com bibendum nisl in massa hendrerit, nec pharetra
dui vehicula. Aread101@cuvox.de Nunc volutpat turpis vitae eros pharetra semper. Morbi
vitae ante sed nisi consequat posuere. Dered1934@superrito.com Suspendisse consectetur posuere
convallis. Ut vitae hendrerit sapien, eu hendrerit leo. In felis purus, QMances6060@einrot.com
dictum et turpis ac, lacinia SDaunt1960@gustr.com suscipit purus. Duis id ipsum interdum,
consequat quam non, ultrices mauris. Etiam tincidunt blandit tortor.";

        string regex = @"[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,4}"; // I use weak regex only for demonstration
        // Use the row below for ordering!
        //var collection = Regex.Matches(text, regex).OfType<Match>().OrderBy(m => m.Value);
        MatchCollection collection = Regex.Matches(text, regex);

        foreach (var email in collection)
        {
            Console.WriteLine(email);
        }
    }
}

// Strongest email regex: http://www.ex-parrot.com/pdw/Mail-RFC822-Address.html
// C# book - LINQ http://shop.oreilly.com/product/0636920023951.do
