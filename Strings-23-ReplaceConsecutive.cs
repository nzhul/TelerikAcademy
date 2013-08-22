using System;
using System.Text;

class ReplaceConsecutive
{
    static void Main()
    {
        string text = "aaaaabbbbbcdddeeeedssaa";

        char prevChar = Char.MinValue;
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] != prevChar)
            {
                builder.Append(text[i]);
                prevChar = text[i];
            }
        }
        Console.WriteLine(builder);
    }
}
