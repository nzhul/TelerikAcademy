using System;
using System.Text;

class CharacterLiterals
{
    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(ConvertToUnicode(input));
    }

    private static string ConvertToUnicode(string input)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            builder.AppendFormat("\\u{0:X4}", (int) input[i]);  
        }
        return builder.ToString();
    }
}
