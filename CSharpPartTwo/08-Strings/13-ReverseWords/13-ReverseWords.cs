// 13. Write a program that reverses the words in given sentence.
//         Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".

using System;
using System.Text.RegularExpressions;
using System.Text;

class Program
{
    static void Main()
    {
        string wordsRegex = @"[^\s\.!?,;:]+";
        string separatorsRegex = @"[\s\.!?,;:]+";
        string sentence = "C# is not C++, not PHP and not Delphi!";

        MatchCollection words = Regex.Matches(sentence, wordsRegex);
        MatchCollection separators = Regex.Matches(sentence, separatorsRegex);

        StringBuilder finalSentence = new StringBuilder();

        for (int i = 0; i < words.Count; i++)
        {
            finalSentence.Append(words[words.Count - 1 - i]);
            finalSentence.Append(separators[i]);
        }

        Console.WriteLine(finalSentence.ToString());
    }
}