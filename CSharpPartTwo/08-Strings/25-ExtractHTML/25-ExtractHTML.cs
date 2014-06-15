// 25. Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. Example:
//     <html>
//         <head><title>News</title></head>
//         <body><p><a href="http://academy.telerik.com">Telerik
//         Academy</a>aims to provide free real-world practical
//         training for young people who want to turn into
//         skillful .NET software engineers.</p></body>
//     </html>


using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractHTML
{
    static void Main()
    {
        string html = File.ReadAllText("../../page.html");
        string regex = "(?<=^|>)[^><]+?(?=<|$)";

        MatchCollection extracts = Regex.Matches(html, regex);

        foreach (var value in extracts)
        {
            Console.WriteLine(value);
        }
    }
}