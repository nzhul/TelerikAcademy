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

// 100/100 solution - zdravko
// https://github.com/hiksa/Telerik-Academy/blob/master/C%23%20Programming/C%23%20Foundamentals%20-%20Part%202/Exam%20Preparations/2011%20-%202012%20-%20Exam%20tasks/6%20Feb/1.PHPVariables/PHPVariables.cs

// 100/100 solution - Console Justification - zdravko
// https://github.com/hiksa/Telerik-Academy/blob/master/C%23%20Programming/C%23%20Foundamentals%20-%20Part%202/Exam%20Preparations/2012%20-%202013%20-%20Exam%20tasks/4%20Feb/4.ConsoleJustification/ConsoleJustification.cs
