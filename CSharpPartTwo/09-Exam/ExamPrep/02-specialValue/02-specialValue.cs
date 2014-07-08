// 90/100 in bgcoder

using System;


class SpecialValue
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] rows = new int[n][];
        for (int i = 0; i < n; i++)
        {
            string[] rowTokens = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            rows[i] = new int[rowTokens.Length];
            for (int j = 0; j < rowTokens.Length; j++)
            {
                rows[i][j] = int.Parse(rowTokens[j]);
            }
        }

        // Init the bool Jagged Array
        bool[][] visited = new bool[rows.Length][];
        for (int i = 0; i < visited.Length; i++)
        {
            visited[i] = new bool[rows[i].Length];
        }


        int maxSpecialValue = int.MinValue;
        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 0; j < rows[i].Length; j++)
            {
                int path = 1;
                int currSpecialValue = 0;
                int rowIndex = i;
                int colIndex = j;
                while (true)
                {
                    if (rows[rowIndex][colIndex] < 0 || visited[rowIndex][colIndex] == true)
                    {
                        currSpecialValue = path + Math.Abs(rows[rowIndex][colIndex]);
                        break;
                    }
                    else
                    {
                        visited[rowIndex][colIndex] = true;
                        colIndex = rows[rowIndex][colIndex];
                        path++;
                        rowIndex++;
                        if (rowIndex >= rows.Length)
                        {
                            rowIndex = 0;
                        }
                    }
                }
                Array.Clear(visited[i], 0, visited[i].Length);
                if (currSpecialValue > maxSpecialValue)
                {
                    maxSpecialValue = currSpecialValue;
                }
            }
            break;
        }
        Console.WriteLine(maxSpecialValue);
    }
}