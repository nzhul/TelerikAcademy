using System;
using System.Text.RegularExpressions;

class ReverseWords
{
    static void Main()
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";
        string regexWords = @"[^\s\,\!]+";
        string regexSeparators = @"[\s\,\!]+";

        MatchCollection words = Regex.Matches(sentence, regexWords);
        MatchCollection separators = Regex.Matches(sentence, regexSeparators);

        foreach (Match match in collection)
        {
            Console.WriteLine(match);
        }
    }
}
