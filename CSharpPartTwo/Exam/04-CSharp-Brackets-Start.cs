using System;
using System.Text;

class CSharpBrackets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string tab = Console.ReadLine();
        int tabCount = 0;
        StringBuilder builder = new StringBuilder();
        StringBuilder tabBuilder = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < line.Length; j++)
            {
                char currChar = line[j];
                if (currChar == '{')
                {
                    builder.Append(currChar);
                    tabCount++;
                    for (int z = 0; z < tabCount; z++)
                    {
                        tabBuilder.Append(tab);
                    }
                    builder.AppendLine();
                    builder.Append(tabBuilder);
                }
                else
                {
                    builder.Append(currChar);
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(builder);
    }
}
