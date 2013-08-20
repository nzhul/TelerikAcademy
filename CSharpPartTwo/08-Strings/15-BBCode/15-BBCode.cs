// 15. Write a program that replaces in a HTML document given as string all the tags
//     <a href="…">…</a> with corresponding tags [URL=…]…/URL]. Sample HTML fragment:

//     <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. 
//     Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>

//     <p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. 
//     Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

class Program
{
    static void Main()
    {
        string html = File.ReadAllText("../../page.html");
        string regex = File.ReadAllText("../../regex.txt");
        Console.WriteLine(Regex.Replace(html, regex, "[URL=$1]$2[/URL]"));
    }
}
// regex = <a\s+href="(.+)">(.+)</a>
// I am using reading from file because of the nasty escaping in VS