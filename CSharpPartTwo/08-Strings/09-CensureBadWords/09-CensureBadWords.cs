using System;
using System.Text.RegularExpressions;

class CensureBadWords
{
    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string words = "PHP, CLR, Microsoft";
        string[] wordsArray = words.Split(new char[] {',',' '},StringSplitOptions.RemoveEmptyEntries);

        string regex = @"\b(" + String.Join("|", wordsArray) + @")\b";
        Console.WriteLine(Regex.Replace(text, regex, m => new String('*', m.Length)));
    }
}