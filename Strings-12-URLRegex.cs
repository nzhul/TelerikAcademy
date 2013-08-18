using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Enter URL adress:");
        string urlInput = Console.ReadLine();
        string regex = @"(?<protocol>^(ht|f)tp(s?))\:\/\/(?<server>(?:www\.)?[a-zA-Z0-9\.]+\.[a-z]{2,4})(?<resource>.*)";

        if (Regex.IsMatch(urlInput,regex))
        {
            MatchCollection collection = Regex.Matches(urlInput, regex);
            foreach (Match m in collection)
            {
                Console.WriteLine("Protocol: {0} ", m.Groups["protocol"].Value);
                Console.WriteLine("Server:   {0}", m.Groups["server"].Value);
                Console.WriteLine("Resource: {0}", m.Groups["resource"].Value);
            }
        }
        else
        {
            Console.WriteLine("Invalid URL Adress!");
        }
    }
}
