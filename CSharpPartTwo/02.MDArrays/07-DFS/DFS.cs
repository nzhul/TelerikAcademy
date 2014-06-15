// 07. * Write a program that finds the largest area of 
// equal neighbor elements in a rectangular matrix and prints its size

using System;


class DFS
{
    static void Main()
    {
        int[,] matrix = 
        {
            {1, 3, 2, 2, 2, 4},
            {3, 3, 3, 2, 4, 4},
            {4, 3, 1, 2, 3, 3},
            {4, 3, 1, 3, 3, 1},
            {4, 3, 3, 3, 1, 1},
        };

        int counter = 0;
        int? BestElement = null;
        bool[,] visited = new bool[matrix.GetLength(0),matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int currentCount = CheckElement(matrix, i, j, matrix[i, j], visited);

                if (currentCount > counter)
                {
                    BestElement = matrix[i, j];
                    counter = currentCount;
                }
            }
        }

        PrintMatrix(matrix, counter, BestElement);

    }

    private static void PrintMatrix(int[,] matrix, int counter, int? BestElement)
    {
        Console.WriteLine("Best Area of equal neighbor elements: ");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == BestElement)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("{0} ", matrix[i, j]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("Size: {0}", counter);
    }

    static bool inRange(int[,] array, int row, int col, bool[,] visited)
    {
        bool inRange = false;
        if ((row >= 0 && row < array.GetLength(0)) && (col >= 0 && col < array.GetLength(1)))
        {
            inRange = true;
        }
        if (inRange)
        {
            if (visited[row, col] == true)
            {
                inRange = false;
            }
        }
        return inRange;
    }

    static int CheckElement(int[,] matrix, int row, int col, int value, bool[,] visited)
    {
        int count = 0;

        if (!inRange(matrix, row, col, visited))
        {
            return count;
        }
        else
        {
            if (matrix[row, col] == value)
            {
                count++;

                visited[row, col] = true;

                count += CheckElement(matrix, row, col + 1, value, visited);
                count += CheckElement(matrix, row, col - 1, value, visited);
                count += CheckElement(matrix, row - 1, col, value, visited);
                count += CheckElement(matrix, row + 1, col, value, visited);
            }
        }
        return count;
    }
}