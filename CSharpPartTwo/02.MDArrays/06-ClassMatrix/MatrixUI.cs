// 06. * Write a class Matrix, to holds a matrix of integers. 
// Overload the operators for adding, subtracting and multiplying of matrices, 
// indexer for accessing the matrix content and ToString().


using System;


class MatrixUI
{
    static void Main()
    {

        // Решението работи само за матрици с еднакви размери!

        Matrix matrix1 = new Matrix(2, 2);
        Matrix matrix2 = new Matrix(2, 2);

        Random rand = new Random();
        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Cols; j++)
            {
                matrix1[i, j] = rand.Next(-5, 15);
                matrix2[i, j] = rand.Next(-5, 15);
            }
        }

        // Addition Test
        Console.WriteLine("Matrix Addition (+): \n");
        Console.WriteLine(matrix1.ToString());
        Console.WriteLine("+\n");
        Console.WriteLine(matrix2.ToString());
        Console.WriteLine("=\n");
        Matrix sum = matrix1 + matrix2;
        Console.WriteLine(sum.ToString());
        Console.WriteLine(new string('-', 20));

        // Subtraction Test
        Console.WriteLine("Matrix Subtraction (-): \n");
        Console.WriteLine(matrix1.ToString());
        Console.WriteLine("-\n");
        Console.WriteLine(matrix2.ToString());
        Console.WriteLine("=\n");
        Matrix sub = matrix1 - matrix2;
        Console.WriteLine(sub.ToString());
        Console.WriteLine(new string('-', 20));

        // Multiplication Test
        Console.WriteLine("Matrix Multiplication (*): \n");
        Console.WriteLine(matrix1.ToString());
        Console.WriteLine("*\n");
        Console.WriteLine(matrix2.ToString());
        Console.WriteLine("=\n");
        Matrix multiply = matrix1 * matrix2;
        Console.WriteLine(multiply.ToString());
        Console.WriteLine(new string('-', 20));

    }
}