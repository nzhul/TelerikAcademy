using System;
using System.IO;
using System.Text.RegularExpressions;


class ContainTest
{
    static void Main()
    {
        string fileContent = File.ReadAllText("../../test.txt");
        File.WriteAllText("../../test.txt",Regex.Replace(fileContent, @"\b(test\w*)\b", String.Empty));
        Console.WriteLine("Replace Complete!");
    }
}
