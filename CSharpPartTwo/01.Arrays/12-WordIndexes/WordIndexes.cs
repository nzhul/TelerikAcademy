// 12. Write a program that creates an array containing all letters from the alphabet (A-Z).
//     Read a word from the console and print the index of each of its letters in the array.


using System;

class WordIndexes
{
    static void Main()
    {
        Console.Write("Enter word: ");
        string word = Console.ReadLine();
        char[] letters = new Char[52];

        for (int i = 0; i < 52; i++)
        {
            if (i < 26)
            {
                letters[i] = (char)(i + 65);
            }
            else
            {
                letters[i] = (char)(i + 71);
            }
        }

        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < letters.Length; j++)
            {
                if (word[i] == letters[j])
                {
                    Console.WriteLine("{0} -> {1}", letters[j], j);
                }
            }
        }

        //// Display the Letters Array for comparison
        //Console.WriteLine();
        //for (int i = 0; i < letters.Length; i++)
        //{
        //    Console.WriteLine("{0} -> {1}  ", letters[i], i);
        //}
    }
}