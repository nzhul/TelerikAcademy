// 13. Write a program that reads a list of words from a file words.txt
//     and finds how many times each of the words is contained in another
//     file test.txt. The result should be written in the file result.txt
//     and the words should be sorted by the number of their occurrences in
//     descending order. Handle all possible exceptions in your methods.


using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

class WordsCount
{
    static void Main()
    {
        string[] words = File.ReadAllLines("../../words.txt");
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        using (StreamReader reader = new StreamReader("../../fileForScaning.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    string regex = @"\b" + words[i] + @"\b";
                    MatchCollection matches = Regex.Matches(line, regex,RegexOptions.IgnoreCase);
                    if (dictionary.ContainsKey(words[i]))
                    {
                        dictionary[words[i]] += matches.Count;
                    }
                    else
                    {
                        dictionary.Add(words[i], matches.Count);
                    }
                }
            }
        }

        using (StreamWriter writer = new StreamWriter("../../result.txt"))
        {
            foreach (var wordCount in dictionary.OrderByDescending(key => key.Value))
            {
                writer.WriteLine("{0} - {1}", wordCount.Key, wordCount.Value);
            }
            Console.WriteLine("Count Complete - Please Check result.txt file!");
        }
    }
}