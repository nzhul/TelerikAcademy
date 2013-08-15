// This file is just a test - it is not part of the homework

using System;
using System.IO;

class EditFile
{
    static void Main()
    {
        string[] file = File.ReadAllLines("../../LandOfConfusion.txt");
        string[] newData = new string[file.Length];

        for (int i = 0; i < file.Length; i++)
        {
            newData[i] = i +". " + file[i];
        }

        File.WriteAllLines("../../LandOfConfusion.txt", newData);
    }
}