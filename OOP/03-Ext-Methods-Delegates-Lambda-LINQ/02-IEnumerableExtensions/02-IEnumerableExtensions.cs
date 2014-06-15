using System;
using System.Collections.Generic;

public static class IEnumerableExtensions
{
    public static T Sum<T>(this IEnumerable<T> input) where T : IComparable
    {
        dynamic sum = 0;
        foreach (var item in input)
        {
            sum += item;
        }
        return sum;
    }

    public static T Product<T>(this IEnumerable<T> input) where T : IComparable
    {
        dynamic product = 1;
        foreach (var item in input)
        {
            product *= item;
        }
        return product;
    }

    public static T Min<T>(this IEnumerable<T> input) where T : IComparable
    {
        dynamic min = int.MaxValue;
        foreach (var item in input)
        {
            if (min > item)
            {
                min = item;
            }
        }
        return min;
    }

    public static T Max<T>(this IEnumerable<T> input) where T : IComparable
    {
        dynamic max = int.MinValue;
        foreach (var item in input)
        {
            if (max < item)
            {
                max = item;
            }
        }
        return max;
    }

    public static T Average<T>(this IEnumerable<T> input) where T : IComparable
    {
        dynamic sum = 0;
        dynamic counter = 0;
        foreach (var item in input)
        {
            sum += item;
            counter++;
        }
        return sum / counter;
    }
}
