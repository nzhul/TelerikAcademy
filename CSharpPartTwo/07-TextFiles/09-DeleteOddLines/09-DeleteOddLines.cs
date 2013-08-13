using System;
using System.Collections.Generic;
using System.IO;

class DeleteOddLines
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("../../file.txt");

        using (StreamWriter writer = new StreamWriter("../../file.txt"))
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (i % 2 != 0)
                {
                    writer.WriteLine(lines[i]);
                }
            }
            Console.WriteLine("Complete!");
        }
    }
}