// 02. Write a program that reads a rectangular matrix of size N x M and finds in 
// it the square 3 x 3 that has maximal sum of its elements.


using System;

class MaxSubMatrix
{
    static void Main()
    {
        //// Uncomment for manual input
        //Console.Write("Enter N: ");
        //int n = int.Parse(Console.ReadLine());
        //Console.Write("Enter M: ");
        //int m = int.Parse(Console.ReadLine());
        //int[,] matrix = new int[n, m];

        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = 0; j < m; j++)
        //    {
        //        Console.Write("Enter Element[{0}, {1}]: ", i, j);
        //        matrix[i, j] = int.Parse(Console.ReadLine());
        //    }
        //}

        // Hardcoded Test5
        int n = 4;
        int m = 6;
        int[,] matrix = 
            {
                { 0, 2, 4, 0, 9, 5 },

                { 7, 1, 3, 3, 2, 1 },

                { 1, 3, 9, 8, 5, 6 },

                { 4, 6, 7, 9, 1, 0 }

            };

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write("{0,4}", matrix[i, j]);
            }
            Console.WriteLine();
        }

        int currentSum = 0;
        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;

        for (int i = 0; i < n - 2; i++)
        {
            for (int j = 0; j < m - 2; j++)
            {
                currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                             matrix[i, j] + matrix[i + 1, j] + matrix[i + 2, j];
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                    bestRow = i;
                    bestCol = j;
                }
            }
        }
        Console.WriteLine();
        for (int i = bestRow; i < bestRow + 3; i++)
        {
            for (int j = bestCol; j < bestCol + 3; j++)
            {
                Console.Write("{0,4}", matrix[i, j]);
            }
            Console.WriteLine();
        }

    }
}
