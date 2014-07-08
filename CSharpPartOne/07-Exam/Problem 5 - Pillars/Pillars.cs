// 90 от 100 точки в bgcoder

using System;


class Pillars
{
    static int SumSide(int[] columnFullCount, int startIndex, int endIndex)
    {
        int sum = 0;
        for (int i = startIndex; i < endIndex; i++)
        {
            sum = sum + columnFullCount[i];
        }
        return sum;
    }

    static void Main()
    {
        string[] binaries = new string[8];
        int[] columnFullCount = new int[8];
        int[] reversedIndex = { 7, 6, 5, 4, 3, 2, 1, 0 };

        for (int i = 0; i < 8; i++)
        {
            binaries[i] = Convert.ToString(byte.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (binaries[i][j] == '1')
                {
                    columnFullCount[j]++;
                }
            }
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int leftSum = SumSide(columnFullCount, 0, i);
                int rightSum = SumSide(columnFullCount, i + 1, 8);
                if (leftSum == rightSum)
                {
                    Console.WriteLine(reversedIndex[i]);
                    Console.WriteLine(leftSum);
                    return;
                }
            }
        }
        Console.WriteLine("No");
    }
}