using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

class phpVariables
{
    static void Main()
    {
        StringBuilder phpCode = new StringBuilder();
        string input = "";
        while (input != "?>")
        {
            input = Console.ReadLine();
            phpCode.Append(input);
        }

        string regex = @"(?<!(((\/\*|#|//)(.+))) | [\\])\$(?<name>\w+)";
        MatchCollection names = Regex.Matches(phpCode.ToString(), regex, RegexOptions.IgnoreCase);
        List<string> uniqueNames = new List<string>();
        foreach (Match name in names.Cast<Match>().OrderBy(m => m.Value))
        {
            if (!uniqueNames.Contains(name.Groups["name"].ToString()))
            {
                uniqueNames.Add(name.Groups["name"].ToString());
            }
        }
        Console.WriteLine(uniqueNames.Count);
        foreach (var uname in uniqueNames)
        {
            Console.WriteLine(uname);
        }
    }
}
