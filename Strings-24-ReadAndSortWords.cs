using System;

class ReadAndSortWords
{
    static void Main()
    {
        string[] words = "diablo mephisto andariel durial azmodan belial seagebreaker baal".Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(words);
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}
