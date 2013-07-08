using System;


class PrintMatrix
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int counter = 1;

        Console.WriteLine();
        Console.WriteLine("Printing Matrix a):");
        for (int c = 0; c < n; c++)
        {
            for (int r = 0; r < n; r++)
            {
                matrix[r, c] = counter;
                counter++;
            }
        }

        Printing(n, matrix);

        counter = 1;
        Console.WriteLine();
        Console.WriteLine("Printing Matrix b)");
        for (int c = 0; c < n; c++)
        {
            if (c % 2 == 0)
            {
                for (int r = 0; r < n; r++)
                {
                    matrix[r, c] = counter;
                    counter++;
                }
            }
            else
            {
                for (int r = n - 1; r >= 0; r--)
                {
                    matrix[r, c] = counter;
                    counter++;
                }
            }
        }

        Printing(n, matrix);

        counter = 1;
        Console.WriteLine();
        Console.WriteLine("Printing Matrix c)");
        int row = n - 1;
        int col = 0;

        for (int i = 1; i < n * n; i++)
        {
            matrix[row, col] = counter;
            row++;
            col++;
            counter++;
            if (row == n || col == n)
            {
                row--;
                if (col == n)
                {
                    row--;
                    col--;
                }
                while (row - 1 >= 0 && col - 1 >= 0)
                {
                    row--;
                    col--;
                }
            }
        }

        Printing(n, matrix);
    }

    private static void Printing(int n, int[,] matrix)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}