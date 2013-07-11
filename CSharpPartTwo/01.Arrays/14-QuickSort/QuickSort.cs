//14. Write a program that sorts an array of strings using 
//    the quick sort algorithm (find it in Wikipedia).


using System;


class QuickSort
{
    static void Main()
    {
        string[] array = { "Dobri", "Evdoki", "Alex", "Cvetan", "Pesho", "Gosho", "Boris" };
        Printing(array);

        // Apply Quicksort
        Quicksort(array, 0, array.Length - 1);

        Printing(array);
    }

    private static void Printing(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }
        Console.WriteLine();
    }

    public static void Quicksort(IComparable[] elements, int left, int right)
    {
        int i = left, j = right;
        IComparable pivot = elements[(left + right) / 2];

        while (i <= j)
        {
            while (elements[i].CompareTo(pivot) < 0)
            {
                i++;
            }
            while (elements[j].CompareTo(pivot) > 0)
            {
                j--;
            }
            if (i <= j)
            {
                // Swap
                IComparable temp = elements[i];
                elements[i] = elements[j];
                elements[j] = temp;

                i++;
                j--;
            }
        }
        if (left < j)
        {
            Quicksort(elements, left, j);
        }
        if (i < right)
        {
            Quicksort(elements, i, right);
        }
    }
}
