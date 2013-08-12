using System;
using System.IO;

class ConcatenateTextFiles
{
    static void Main()
    {
        string firstFile = File.ReadAllText("../../barbarians.txt");
        string secondFile = File.ReadAllText("../../wizards.txt");

        using (StreamWriter writer = File.CreateText("../../combine.txt"))
        {
            writer.Write(firstFile + Environment.NewLine + secondFile);
            Console.WriteLine("The combined file was created!");
        }
    }
}
