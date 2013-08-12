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