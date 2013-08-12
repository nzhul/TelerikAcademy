using System;
using System.IO;

class MaxSubMatrix
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("../../matrix.txt");
        int matrixSize = int.Parse(lines[0]);
        int[,] matrix = new int[matrixSize, matrixSize];

        // we start from i = 1
        for (int i = 1; i < lines.Length; i++)
        {
            string[] currentLine = lines[i].Split();
            for (int j = 0; j < currentLine.Length; j++)
            {
                matrix[i - 1, j] = int.Parse(currentLine[j]);
            }
        }

        Console.WriteLine(FindMaxSubmatrix(matrix));
    }

    static int FindMaxSubmatrix(int[,] matrix)
    {
        int currentSum = 0;
        int bestSum = int.MinValue;

        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                currentSum = matrix[i, j] + matrix[i, j + 1] +
                             matrix[i + 1, j] + matrix[i + 1, j + 1];
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                }
            }
        }
        return bestSum;
    }
}
