// 15. * Modify your last program and try to make it work for any number type, not
//     just integer (e.g. decimal, float, byte, etc.). Use generic method 
//     (read in Internet about generic methods in C#).


using System;

class GenericMethods
{
    static void Main()
    {
        Console.WriteLine("Min: {0}", Min(4, 2, 1, 3));
        Console.WriteLine("Max: {0}", Max(4, 2, 1, 3));
        // Average(); - Важно е да подадем поне едно число от дип double за да извъши правилно изчислението
        Console.WriteLine("Average: {0}", Average(4.0, 2, 1, 3));
        Console.WriteLine("Sum: {0}", Sum(4, 2, 1, 3));
        Console.WriteLine("Product: {0}", Product(4, 2, 1, 3));
    }

    static T Product<T>(params T[] sequence)
    {
        dynamic product = 1;
        for (int i = 0; i < sequence.Length; i++)
        {
            product *= sequence[i];
        }
        return product;
    }

    static T Sum<T>(params T[] sequence)
    {
        dynamic sum = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            sum += sequence[i];
        }
        return sum;
    }

    static T Average<T>(params T[] sequence)
    {
        dynamic sum = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            sum += sequence[i];
        }

        return sum / sequence.Length;
    }

    static T Max<T>(params T[] sequence)
    {
        dynamic bestMax = int.MinValue;
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] > bestMax)
            {
                bestMax = sequence[i];
            }
        }
        return bestMax;
    }

    static T Min<T>(params T[] sequence)
    {
        dynamic bestMin = int.MaxValue;
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