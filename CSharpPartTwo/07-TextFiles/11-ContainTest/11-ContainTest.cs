// 11. Write a program that deletes from a text file all words that start with 
//     the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.


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
