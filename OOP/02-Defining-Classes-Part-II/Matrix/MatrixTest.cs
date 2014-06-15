using System;

namespace Matrix
{
    class MatrixTest
    {
        static void Main()
        {
            Matrix<int> m1 = new Matrix<int>(3, 3);
            Matrix<int> m2 = new Matrix<int>(3, 3);

            Random rand = new Random();
            m1[0, 0] = rand.Next(0, 15); m1[0, 1] = rand.Next(0, 15); m1[0, 2] = rand.Next(0, 15);
            m1[1, 0] = rand.Next(0, 15); m1[1, 1] = rand.Next(0, 15); m1[1, 2] = rand.Next(0, 15);
            m1[2, 0] = rand.Next(0, 15); m1[2, 1] = rand.Next(0, 15); m1[2, 2] = rand.Next(0, 15);

            m2[0, 0] = rand.Next(0, 15); m2[0, 1] = rand.Next(0, 15); m2[0, 2] = rand.Next(0, 15);
            m2[1, 0] = rand.Next(0, 15); m2[1, 1] = rand.Next(0, 15); m2[1, 2] = rand.Next(0, 15);
            m2[2, 0] = rand.Next(0, 15); m2[2, 1] = rand.Next(0, 15); m2[2, 2] = rand.Next(0, 15);

            Console.WriteLine("Adding Matrices:");
            Console.WriteLine(new String('-', 30));
            Console.WriteLine(m1);
            Console.WriteLine("+");
            Console.WriteLine(m2);
            Console.WriteLine("=");
            Console.WriteLine(m1 + m2);

            Console.WriteLine("Subtracting Matrices:");
            Console.WriteLine(new String('-', 30));
            Console.WriteLine(m1);
            Console.WriteLine("-");
            Console.WriteLine(m2);
            Console.WriteLine("=");
            Console.WriteLine(m1 - m2);

            Console.WriteLine("Multiply Matrices:");
            Console.WriteLine(new String('-', 30));
            Console.WriteLine(m1);
            Console.WriteLine("*");
            Console.WriteLine(m2);
            Console.WriteLine("=");
            Console.WriteLine(m1 * m2);

            Console.WriteLine("Compare Matrices:");
            Console.WriteLine(new String('-', 30));
            if (m1 == m2)
            {
                Console.WriteLine("Matrix 1 = Matix 2");
            }
            else
            {
                Console.WriteLine("Matrix 1 != matrix 2");
            }
        }
    }
}
