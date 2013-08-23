// 24. Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;

class ReadAndSortWords
{
    static void Main()
    {
        string[] words = "diablo mephisto andariel durial azmodan belial seagebreaker baal".Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(words);
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}