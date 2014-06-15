// 03. Write a program that reads a text file and inserts line numbers
//     in front of each of its lines. The result should be written to another text file.


using System;
using System.IO;


class LineNumbers
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("../../LandOfConfusion.txt"))
        {
            using(StreamWriter writer = new StreamWriter("../../SongWithLineNumbers.txt"))
            {
                string line;
                int lineCounter = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine("{0}. {1}", lineCounter, line);
                    lineCounter++;
                }
                Console.WriteLine("Lines added!");
            }
        }
    }
}