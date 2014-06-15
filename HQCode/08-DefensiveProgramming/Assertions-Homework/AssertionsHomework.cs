using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

static class Program
{
    private static bool IsSorted<T>(this IEnumerable<T> elements) where T : IComparable<T>
    {
        if (!elements.Any())
            return true;

        T current = elements.First();

        foreach (T item in elements.Skip(1))
        {
            if (current.CompareTo(item) > 0)
                return false;

            current = item;
        }

        return true;
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null!");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);

            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        Debug.Assert(arr.IsSorted(), "Array is not sorted!");
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndexInclusive)
        where T : IComparable<T>
    {
        int minElementIndex = startIndex;

        for (int i = startIndex + 1; i <= endIndexInclusive; i++)
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                minElementIndex = i;

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null!");
        Debug.Assert(arr.IsSorted(), "Array is not sorted!");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        while (startIndex <= endIndex)
        {
            int midIndex = startIndex + (endIndex - startIndex) / 2;
            int compared = arr[midIndex].CompareTo(value);

            if (compared < 0)
                startIndex = midIndex + 1;

            else if (compared > 0)
                endIndex = midIndex - 1;

            else return midIndex;
        }

        Debug.Assert(!arr.Contains(value), String.Format("Array contains {0}!", value));
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));

        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]);
        SelectionSort(new int[1]);

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}