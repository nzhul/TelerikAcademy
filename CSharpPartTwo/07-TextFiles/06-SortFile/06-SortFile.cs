// 06. Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. Example:
//         Ivan			George
//         Peter			Ivan
//         Maria			Maria
//         George			Peter


using System;
using System.IO;
using System.Linq;

    class SortFile
    {
        static void Main()
        {
            string[] fileLines = File.ReadLines("../../file.txt").ToArray();
            Array.Sort(fileLines);
            File.WriteAllLines("../../sortedFile.txt", fileLines);
        }
    }