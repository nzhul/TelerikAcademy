// 14. * Write a program that reads a positive integer number N (N < 20) 
// from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.


using System;

class SpiralMatrix
{
    static void Main()
    {
        int n = 5;
        int[,] matrix = new int[n, n];

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                matrix[r, c] = c + 1;
            }
        }

        // Display The Matrix
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                Console.Write(matrix[r, c]);
            }
            Console.WriteLine();
        }


    }
}
