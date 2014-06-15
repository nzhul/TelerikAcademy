// 14. Write methods to calculate minimum, maximum, average, sum and product of 
//     given set of integer numbers. Use variable number of arguments.


using System;

class VariableArguments
{
    static void Main()
    {
        Console.WriteLine("Min: {0}", Min(4, 2, 1, 3));
        Console.WriteLine("Max: {0}", Max(4, 2, 1, 3));
        Console.WriteLine("Average: {0}", Average(4, 2, 1, 3));
        Console.WriteLine("Sum: {0}", Sum(4, 2, 1, 3));
        Console.WriteLine("Product: {0}", Product(4, 2, 1, 3));
    }

    static int Product(params int[] sequence)
    {
        int product = 1;
        for (int i = 0; i < sequence.Length; i++)
        {
            product *= sequence[i];
        }
        return product;
    }

    static int Sum(params int[] sequence)
    {
        int sum = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            sum += sequence[i];
        }
        return sum;
    }

    static double Average(params int[] sequence)
    {
        double sum = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            sum += sequence[i];
        }

        return sum / sequence.Length;
    }

    static int Max(params int[] sequence)
    {
        int bestMax = int.MinValue;
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] > bestMax)
            {
                bestMax = sequence[i];
            }
        }
        return bestMax;
    }

    static int Min(params int[] sequence)
    {
        int bestMin = int.MaxValue;
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] < bestMin)
            {
                bestMin = sequence[i];
            }
        }
        return bestMin;
    }
}