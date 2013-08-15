using System;
using System.Text.RegularExpressions;

class SubstringCount
{
    static void Main()
    {
        string input = @"We are living in an yellow submarine.
        We don't have anything else. Inside the submarine is very tight. 
        So we are drinking all the day. We will move out of it in 5 days.";
        Console.WriteLine(Regex.Matches(input, "in",RegexOptions.IgnoreCase).Count);
    }
}