//17. * Write a program that reads three integer numbers N, K and S 
//    and an array of N elements from the console. Find in the array a 
//    subset of K elements that have sum S or indicate about its absence.


using System;
using System.Collections.Generic;

class SubsetSum
{
    static void Main()
    {
        Console.Write("Enter the subset length (k):");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Enter the array length (n):");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter the desired sum (s):");
        int s = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter element {0} from the array: ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }
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
            int currentLength = 0;
            List<int> sublist = new List<int>();
            for (int j = 0; j < numbers.Length; j++)
            {
                int mask = 1 << j;
                int nAndMask = i & mask;
                int bit = nAndMask >> j;
                if (bit == 1)
                {
                    currentSum += numbers[j];
                    currentLength++;
                    sublist.Add(numbers[j]);
                }
            }
            if (currentSum == s && currentLength == k)
            {
                // YES
                list.Add(sublist);
                count++;
            }
        }
        Console.WriteLine("There are/is {0} Subset(s) with length of {1} that has sum of {2}:", count,k , s);
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