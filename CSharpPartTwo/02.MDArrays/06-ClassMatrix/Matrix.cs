// 06. * Write a class Matrix, to holds a matrix of integers. 
// Overload the operators for adding, subtracting and multiplying of matrices, 
// indexer for accessing the matrix content and ToString().

// This is the class file - The file with the Main Method is MatrixUI.cs

using System;

class Matrix
{
    // Решението работи само за матрици с еднакви размери!

    private int[,] matrix;

    // Constructor
    public Matrix(int rows, int cols)
    {
        this.matrix = new int[rows, cols];
    }

    public int Rows
    {
        get { return this.matrix.GetLength(0); }
    }

    public int Cols
    {
        get { return this.matrix.GetLength(1); }
    }

    // Add (+) operator overload
    public static Matrix operator +(Matrix first, Matrix second)
    {
        Matrix result = new Matrix(first.Rows, first.Cols);
        for (int i = 0; i < first.Rows; i++)
        {
            for (int j = 0; j < first.Cols; j++)
            {
                result[i, j] = first[i, j] + second[i, j];
            }
        }

        return result;
    }

    // Subtract (-) operator overload
    public static Matrix operator -(Matrix first, Matrix second)
    {
        Matrix result = new Matrix(first.Rows, first.Cols);
        for (int i = 0; i < first.Rows; i++)
        {
            for (int j = 0; j < first.Cols; j++)
            {
                result[i, j] = first[i, j] - second[i, j];
            }
        }
        return result;
    }

    // Multiply (*) operator overload
    public static Matrix operator *(Matrix first, Matrix second)
    {
        Matrix result = new Matrix(first.Rows, first.Cols);
        for (int i = 0; i < first.Rows; i++)
        {
            for (int j = 0; j < first.Cols; j++)
            {
                for (int k = 0; k < first.Cols; k++)
                {
                    result[i, j] += first[i, k] * second[k, j];
                }
            }
        }
        return result;
    }

    // Getter Setter
    public int this[int row, int col]
    {
        get { return this.matrix[row, col]; }
        set { this.matrix[row, col] = value; }
    }


    public override string ToString()
    {
        string result = null;
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Cols; col++)
            {
                result += matrix[row, col] + " ";
            }
            result += Environment.NewLine;
        }
        return result;
    }
}