// 06. Write a method that returns the index of the first element 
//     in array that is bigger than its neighbors, or -1, if there’s no such element.

using System;

class TwoNeighborsBigger
{
    static int FindFisrtElemBiggerThanItsNeighbors(int[] arr, int length)
    {
        int element = -1;
        for (int i = 1; i < length - 1; i++)
        {
            if (arr[i] > arr[i - 1] + arr[i + 1])
            {
                element = i;
                return element;
            }
        }
        return element;
    }
    static void Main()
    {
        int[] arr = { 1, 1, 2, 1, 1, 4, 1, 1, 2, 1 };
        int length = arr.Length;
        int firstelement = FindFisrtElemBiggerThanItsNeighbors(arr, length);
        if (firstelement != -1)
        {
            Console.WriteLine("The index of first element wich is bigger than its neighbors is:[{0}]", firstelement);
        }
        else
        {
            Console.WriteLine("There is no such element");
        }

    }
}