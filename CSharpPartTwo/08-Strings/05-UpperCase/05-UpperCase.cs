using System;
using System.Linq;
using System.Text.RegularExpressions;


class UpperCase
{
    static void Main()
    {
        string input = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string result = Regex.Replace(input, @"<upcase>([\w\s]*)</upcase>", match => match.Groups[1].Value.ToUpper());
        Console.WriteLine(result);
    }
}