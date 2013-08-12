using System;
using System.IO;
using System.Linq;

    class SortFile
    {
        static void Main()
        {
            string[] fileLines = File.ReadLines("../../file.txt").ToArray();
            Array.Sort(fileLines); // this is for default lexicograph sorting
            File.WriteAllLines("../../sortedFile.txt", fileLines);
        }
    }