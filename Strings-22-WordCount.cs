using System;
using System.Linq;
using System.Collections.Generic;

class LetterCount
{
    static void Main()
    {
        string input = Console.ReadLine();

        Dictionary<char, int> dictionary = new Dictionary<char, int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (dictionary.ContainsKey(input[i]))
            {
                dictionary[input[i]]++; 
            }
            else
            {
                dictionary.Add(input[i], 1);
            }
        }

        foreach (var letter in dictionary.OrderByDescending(m => m.Value))
        {
            Console.WriteLine("{0} - {1}", letter.Key, letter.Value);
        }
    }
}
