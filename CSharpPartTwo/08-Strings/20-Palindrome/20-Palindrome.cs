// 20. Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;
using System.Text.RegularExpressions;

class Palindrome
{
    static void Main()
    {
        string text = 
@"The most familiar palindromes, in English at least, 
are character-by-character: The written characters read the same 
backward as forward. Some examples of common palindromic words: civic,
radar, level, rotor, kayak, reviver, racecar, redder, madam, malayalam, 
and refer.";

        string regex = @"\b\w+\b";

        MatchCollection words = Regex.Matches(text, regex);

        foreach (Match word in words)
        {
            if (isPalindrome(word))
            {
                Console.WriteLine(word);
            }
        }

    }

    static bool isPalindrome(Match word)
    {
        string wordString = word.ToString();
        for (int i = 0; i < wordString.Length; i++)
        {
            if (wordString[i] != wordString[wordString.Length - i - 1])
            {
                return false;
            }
        }
        return true;
    }
}