//Strings are collections of characters. Strings are actualy char arrays.
//Strings are readOnly - That means that they cannot be modified.
//If you want to modify string - you must create new string and copy all of the old characters to it - together with the new characters
// 
//Strings are referal type of object in C#. That means that they use the Heap memory for storage.
//
//One of the most important String Methods are:
// - Split: this one splits the string into other string[] array based on specified delimiter
// - IndexOf: Returns the position (index) of the first occurance of the specified character or substring
// - Concat / Join: You can concatenate or join multiple strings onto one with specific delimiter of desired
// - Replace: It replaces specific substring with new one
// - Length: This one returns the length of the string(the length of the char[] array)
// - Substring: Crop part of the string based on Starting index and crop length
// - ToUpper, ToLower - self explanatory. Uppers or Lowers the case of the string.
// - Trim, TrimEnd, TrimStart: Removes the whitespace at the start and at the end of the string
// - Padleft and PadRight - Trimming a string removes extra characters on either end. Padding a string instead adds extra characters.
//
using System;


class DescribeStrings
{
    static void Main()
    {
        Console.WriteLine("Check the comments in the source code!");
    }
}