//09. Write a program that finds the most frequent number in an array. Example:
//    {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)


using System;

class Program
{
    static void Main()
    {
        int[] numbers = { -1, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        int finalMax = 0;
        int currentMax = 0;
        int MaxElement = numbers[0];

        for (int i = 0; i < numbers.Length; i++)
        {
            currentMax = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    currentMax++;
                }
            }
            if (finalMax < currentMax)
            {
                finalMax = currentMax;
                MaxElement = numbers[i];
            }
        }

        Console.WriteLine("The most frequent number in the array is -> {0}({1} times)", MaxElement, finalMax);
    }
}