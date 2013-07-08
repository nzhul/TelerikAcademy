//  07. Sorting an array means to arrange its elements in increasing order. 
//      Write a program to sort an array. Use the "selection sort" algorithm: 
//      Find the smallest element, move it at the first position, find the 
//      smallest from the rest, move it at the second position, etc.


using System;

class SelectionSort
{
    static void Main()
    {
        int[] array = { 66, 90, 42, 11, 32, 44, 33, 61, 24, 42, 5, 7, 51, 3, 23, 84, 20, 22, 16, 73, 43, 33, 66, 39, 99,
                        88, 6, 51, 53, 25, 57, 95, 31, 61, 17, 81, 22, 61, 68, 52, 64, 32, 67, 38, 48, 58, 45, 62, 40, 19};

        //int[] array = {-2, 1, -2, 5, 3, 3, 4, };

        int startingPosition = 0;
        while (startingPosition <= array.Length - 1)
        {
            int currentMinIndex = 0;
            int currentMin = int.MaxValue;
            for (int i = startingPosition; i < array.Length; i++)
            {
                if (array[i] < currentMin)
                {
                    currentMin = array[i];
                    currentMinIndex = i;
                }
            }
            int temp = array[startingPosition];

            array[startingPosition] = currentMin;
            array[currentMinIndex] = temp;
            startingPosition++;
        }

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("{0}: {1}", i, array[i]);
        }
    }
}
// I am using the SelectionSort algorithm.
// Actualy i'v come alone to that algorithm because it is very simple.
// You can find more information about the algorithm on
// wikipedia: http://en.wikipedia.org/wiki/Selection_sort
// You can also check this usefull website that visualize the sorting algorithms in action:
// http://www.cs.usfca.edu/~galles/visualization/ComparisonSort.html (Click "Selection Sort" button)
//
//
//
//
//