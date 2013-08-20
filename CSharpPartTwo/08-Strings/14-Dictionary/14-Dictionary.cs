// 14. A dictionary is stored as a sequence of text lines containing words and their 
//     explanations. Write a program that enters a word and translates it by using the dictionary. Sample dictionary:

//     .NET – platform for applications from Microsoft
//     CLR – managed execution environment for .NET
//     namespace – hierarchical organization of classes

using System;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text =
@".NET - platform for applications from Microsoft 
CLR - managed execution environment for .NET namespace – hierarchical organization of classes
Barbarian - Savage warrior that uses brute force to eliminate his foes!
Metallica - ... And Justice For All!";
        string key = Console.ReadLine();
        Match m = Regex.Match(text, key + @"\s\-\s(?<desc>.+)", RegexOptions.IgnoreCase);
        Console.WriteLine(m.Groups["desc"]);
    }
}

// Whatch out with the LONG DASHES!!!