using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractHTML
{
    static void Main()
    {
        string html = File.ReadAllText("../../page.html");
        string regex = "(?<=^|>)[^><]+?(?=<|$)";

        MatchCollection extracts = Regex.Matches(html,regex);

        foreach (var value in extracts)
        {
            Console.WriteLine(value);
        }
    }
}
