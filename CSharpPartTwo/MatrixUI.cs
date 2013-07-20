using System;


class MatrixUI
{
  static void Main()
  {
    Matrix matrix1 = new Matrix(2, 2);
    matrix1[0, 0] = 1;
    matrix1[1, 1] = -12;

    Matrix matrix2 = new Matrix(2, 2);
    matrix2[0, 1] = 2;
    matrix2[1, 1] = 24;

    Matrix sum = matrix1 + matrix2;
    Console.WriteLine(sum.ToString());

                                 
  }
}
