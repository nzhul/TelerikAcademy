// 04. Write a program that compares two text files line by line 
//     and prints the number of lines that are the same and the 
//     number of lines that are different. Assume the files have 
//     equal number of lines.


using System;
using System.IO;

class SameLine
{
    static void Main()
    {
        string[] file1 = File.ReadAllLines("../../file1.txt");
        string[] file2 = File.ReadAllLines("../../file2.txt");

        int same = 0;
        for (int i = 0; i < file1.Length; i++)
        {
            if (file1[i] == file2[i])
            {
                same++;
            }
        }

        Console.WriteLine("file1.txt: ");
        PrintFileContent(file1);
        Console.WriteLine();
        Console.WriteLine("file2.txt: ");
        PrintFileContent(file2);
        Console.WriteLine();

        Console.WriteLine("Same Lines: {0}", same);
        Console.WriteLine("Different Lines {0}", file1.Length - same);
    }

    static void PrintFileContent(string[] file)
    {
        for (int i = 0; i < file.Length; i++)
        {
            Console.WriteLine(file[i]);
        }
    }
}
