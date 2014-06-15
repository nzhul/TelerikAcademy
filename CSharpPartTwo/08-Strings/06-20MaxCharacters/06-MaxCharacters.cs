// 06. Write a program that reads from the console a string of maximum 20 characters. 
//     If the length of the string is less than 20, the rest of the characters should be filled 
//     with '*'. Print the result string into the console.

using System;
using System.IO;

class MaxCharacters
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please Enter string <= 20 characters");
            string input = Console.ReadLine();
            if (input.Length > 20)
            {
                continue;
            }
            else
            {
                Console.WriteLine(input.PadRight(20, '*'));
                break;
            }
        }
    }
}