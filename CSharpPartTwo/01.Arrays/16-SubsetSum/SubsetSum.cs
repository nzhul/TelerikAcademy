//16. * We are given an array of integers and a number S. 
//    Write a program to find if there exists a subset of the elements 
//    of the array that has a sum S. Example:
//    arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)


using System;
using System.Collections.Generic;

class SubsetSum
{
    static void Main()
    {
        Console.Write("Enter the desired sum (s):");
        int s = int.Parse(Console.ReadLine());
        int[] numbers = { 2, 1, 2, 4, 3, 5, 2, 6 };
        List<List<int>> list = new List<List<int>>();

        //int maxI = 1;
        //for (int i = 1; i <= numbers.Length; i++)
        //{
        //    maxI *= 2;
        //}
        //maxI -= 1;
        int maxI = (int)Math.Pow(2, numbers.Length) - 1;
        int count = 0;
        for (int i = 1; i <= maxI; i++)
        {
            int currentSum = 0;
            List<int> sublist = new List<int>();
            for (int j = 0; j < numbers.Length; j++)
            {
                int mask = 1 << j;
                int nAndMask = i & mask;
                int bit = nAndMask >> j;
                if (bit == 1)
                {
                    currentSum += numbers[j];
                    sublist.Add(numbers[j]);
                }
            }
            if (currentSum == s)
            {
                // YES
                list.Add(sublist);
                count++;
            }
        }
        Console.WriteLine("There are {0} Subsets that has sum of {1}:", count, s);
        foreach (var sublist in list)
        {
            foreach (var value in sublist)
            {
                Console.Write(value);
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
}