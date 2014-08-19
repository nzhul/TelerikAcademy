using System;
using System.Linq;

namespace Complexity
{
    class Program
    {
        static void Main()
        {
            // 1.Compute O(N^2 - 2*N) returns 255 in this case we have 17 numbers in the array N = 17
            // 17^2 = 289 - 2*17 = 255
            int[] array = 34653475634634796.ToString().ToArray().Select(s => int.Parse(s.ToString())).ToArray();
            Console.WriteLine(Compute(array));

            // 2.CalcCount matrix n*(m/2) in this case N = 8 (the number of rows) and M = 4 (the numbers of columns)
            // and the result is: 16
            int[,] matrix = 
            {
                {1,2,3,4},
                {4,5,6,7},
                {7,8,9,0},
                {4,5,6,7}
            };

            Console.WriteLine(CalcCount(matrix));
        }

        static long Compute(int[] arr)
        {
            long count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int start = 0, end = arr.Length - 1;
                while (start < end)
                {
                    if (arr[start] < arr[end])
                    {
                        start++;
                        count++;
                    }
                    else
                    {
                        end--;
                    }
                }
            }
            return count;
        }

        static long CalcCount(int[,] matrix)
        {
            long count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, 0] % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] > 0)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}