// 09. We are given a string containing a list of forbidden words and a text containing some of these words.
//     Write a program that replaces the forbidden words with asterisks. Example:

//     Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 
//     and is implemented as a dynamic language in CLR.

//     Words: "PHP, CLR, Microsoft"
//            The expected result:

//     ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 
//     and is implemented as a dynamic language in ***.




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