//18. * Write a program that reads an array of integers and removes from it a 
//    minimal number of elements in such way that the remaining array is sorted in 
//    increasing order. Print the remaining sorted array. Example:
//    {6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}


using System;
using System.Collections.Generic;

class LongestIncreasingSubsequence
{
    static void Main()
    {
        int[] numbers = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        // int[] numbers = { 1, 2 ,1 ,1 , 1};
        List<int> currentList = new List<int>();
        List<int> maxList = new List<int>();

        int maxI = (int)Math.Pow(2, numbers.Length) - 1;
        for (int i = 1; i <= maxI; i++)
        {
            List<int> sublist = new List<int>();
            for (int j = 0; j < numbers.Length; j++)
            {
                int mask = 1 << j;
                int nAndMask = i & mask;
                int bit = nAndMask >> j;
                if (bit == 1)
                {
                    currentList.Add(numbers[j]);
                }
            }
            if (isSorted(currentList))
            {
                if (currentList.Count > maxList.Count)
                {
                    maxList.Clear();
                    for (int j = 0; j < currentList.Count; j++)
                    {
                        maxList.Add(currentList[j]);
                    }
                }
                currentList.Clear();
            }
            else
            {
                currentList.Clear();
            }
        }

        foreach (var value in maxList)
        {
            Console.Write(value);
            Console.Write(' ');
        }
    }
    static bool isSorted(List<int> currentList)
    {
        for (int i = 0; i < currentList.Count - 1; i++)
        {
            if (currentList[i + 1] >= currentList[i])
            {
                continue;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}