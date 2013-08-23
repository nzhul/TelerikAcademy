// 21. Write a program that reads a string from the console and prints all different 
//     letters in the string along with information how many times each letter is found. 


using System;
using System.Linq;
using System.Collections.Generic;

class Strings
{
    static void Main()
    {
        Console.WriteLine("Enter text: ");
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
