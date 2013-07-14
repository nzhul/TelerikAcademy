//19. * Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. Example:
//      n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}


using System;

class Permutations
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 1; i <= n; i++)
        {
            numbers[i - 1] = i;
        }

        Permutate(numbers, 0, n - 1);

    }

    static void Permutate(int[] array, int index, int length)
    {
        if (index == length)
        {
            PrintArray(length, array);
        }
        else
        {
            for (int i = index; i <= length; i++)
            {
                Swap(ref array[i], ref array[index]);
                Permutate(array, index + 1, length);
                Swap(ref array[i], ref array[index]);
            }
        }
    }
  
    static void PrintArray(int length, int[] array)
    {
        for (int i = 0; i <= length; i++)
        {
            Console.Write("{0} ", array[i]);
        }
        Console.WriteLine();
    }

    static void Swap(ref int first, ref int second)
    {
        int temp = first;
        first = second;
        second = temp;
    }
}