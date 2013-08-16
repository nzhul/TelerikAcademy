using System;
using System.Text.RegularExpressions;


class MatchSentence
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        MatchCollection matchList = Regex.Matches(text, @"([^\.]*\bin\b[^\.]*)");
        foreach (Match sentence in matchList)
        {
            Console.WriteLine(sentence);
        }
    }
}
