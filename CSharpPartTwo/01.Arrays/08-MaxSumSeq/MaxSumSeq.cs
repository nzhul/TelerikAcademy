//08. Write a program that finds the sequence of maximal sum in given array. Example:
//    {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
//    Can you do it with only one loop (with single scan through the elements of the array)?


using System;

class MaxSumSeq
{
    static void Main()
    {
        //int[] numbers = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        //int[] numbers = { -2, -3, 4, -1, -2, 1, 5, -3 };
        int[] numbers = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        int maxSoFar = numbers[0];
        int maxEndingHere = numbers[0];
        int begin = 0;
        int begin_temp = 0;
        int end = 0;

        for (int i = 1; i < numbers.Length; i++)
        {
            if (maxEndingHere < 0)
            {
                maxEndingHere = numbers[i];
                begin_temp = i;
            }
            else
            {
                maxEndingHere += numbers[i];
            }
            // calculate max so far
            if (maxEndingHere >= maxSoFar)
            {
                maxSoFar = maxEndingHere;
                begin = begin_temp;
                end = i;
            }
        }

        //Display the Maximum Sum Sequence
        for (int i = begin; i <= end; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }
        Console.WriteLine("Sum = {0}", maxSoFar);
    }
}
// I am using the Kadane's algorithm
// You can find more information about that algorithm here:
// wikipedia: http://en.wikipedia.org/wiki/Maximum_subarray_problem
//
//