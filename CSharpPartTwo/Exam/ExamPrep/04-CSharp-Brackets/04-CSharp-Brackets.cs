using System;
using System.Text;
using System.Text.RegularExpressions;

class CSharpBrackets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string tab = Console.ReadLine();
        int tabCount = 0;
        StringBuilder builder = new StringBuilder();
        
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            line = Regex.Replace(line, @"\s+", " ");
            line = line.Trim();
            for (int j = 0; j < line.Length; j++)
            {
                char currChar = line[j];
                if (currChar == '{')
                {
                    // Space in the begining of the line fix
                    if (j < line.Length - 1 && line[j + 1] == ' ')
                    {
                        j++;
                    }
                    builder.AppendLine();
                    builder.Append(TabBuilder(tabCount, tab));
                    builder.Append('{');
                    builder.AppendLine();
                    tabCount++;
                }
                else if (currChar == '}')
                {
                    tabCount--;
                    builder.AppendLine();
                    builder.Append(TabBuilder(tabCount, tab));
                    builder.Append('}');
                    builder.AppendLine();
                }
                else
                {
                    if (j == 0)
                    {
                        builder.AppendLine();
                    }
                    builder.Append(TabBuilder(tabCount, tab));
                    while (j < line.Length && line[j] != '{' && line[j] != '}')
                    {
                        builder.Append(line[j]);
                        j++;
                    }
                    j--;
                }
            }
        }
        string[] finalOutput = builder.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        builder.Clear();
        for (int i = 0; i < finalOutput.Length; i++)
        {
            Match match = Regex.Match(finalOutput[i], @"^\s+$");
            if (match.Success)
            {
                continue;
            }
            else
            {
                builder.Append(finalOutput[i]);
                if (i != finalOutput.Length - 1)
                {
                    builder.AppendLine();
                }
            }
        }
        Console.WriteLine(builder);
    }

    static string TabBuilder(int tabCount, string tab)
    {
        StringBuilder builder = new StringBuilder();
        for (int z = 0; z < tabCount; z++)
        {
            builder.Append(tab);
        }
        return builder.ToString();
    }
}