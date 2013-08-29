using System;


class SpecialValue
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] rows = new int[n][];
        for (int i = 0; i < n; i++)
        {
            string[] rowTokens = Console.ReadLine().Split(new char[] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries );
            rows[i] = new int[rowTokens.Length];
            for (int j = 0; j < rowTokens.Length; j++)
            {
                rows[i][j] = int.Parse(rowTokens[j]);
            }
        }
    }
}