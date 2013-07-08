// 06. Write a program that reads two integer numbers N and K and an array 
//     of N elements from the console. Find in the array those K elements that have maximal sum.


using System;

class MaxSum
{
    static void Main()
    {
        Console.Write("Enter the array size(n): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        if (k > n)
        {
            Console.WriteLine("N must be bigger than K");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element[{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(array);

        Console.WriteLine();
        Console.WriteLine("Sum the {0} biggest elements from array of {1} elements:", k, n);
        int sum = 0;
        for (int i = 0; i < k; i++)
        {
            Console.WriteLine("Element[{0}] = {1} ", array.Length - 1 - i, array[array.Length - 1 - i]);
            sum += array[array.Length - 1 - i];
        }
        Console.WriteLine("Total Sum: {0}", sum);


    }
}