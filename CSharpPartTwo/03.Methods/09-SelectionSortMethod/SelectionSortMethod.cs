using System;


class SelectionSortMethod
{
    static void Main()
    {
        int[] numbers = { 66, 90, 42, 11, 32, 44, 33, 61, 24, 42, 5, 7, 51, 3, 23, 84, 20, 22, 16, 73, 43, 33, 66, 39, 99,
                        88, 6, 51, 53, 25, 57, 95, 31, 61, 17, 81, 22, 61, 68, 52, 64, 32, 67, 38, 48, 58, 45, 62, 40, 19};

        for (int i = 0; i < numbers.Length; i++)
        {
            int maxIndex = FindMax(numbers, i);
            int temp = numbers[i];
            numbers[i] = numbers[maxIndex];
            numbers[maxIndex] = temp;
        }

        Console.WriteLine("Descending Order: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i % 10 == 0)
            {
                Console.Write("\n");
            }
            Console.Write("{0} ", numbers[i]);
        }
        Console.WriteLine("\n\nAscending Order: ");
        Array.Reverse(numbers);
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i % 10 == 0)
            {
                Console.Write("\n");
            }
            Console.Write("{0} ", numbers[i]);
        }

    }

    private static int FindMax(int[] numbers, int startingIndex)
    {
        int currentMax = int.MinValue;
        int currentMaxIndex = startingIndex;
        for (int j = startingIndex; j < numbers.Length; j++)
        {
            if (numbers[j] > currentMax)
            {
                currentMax = numbers[j];
                currentMaxIndex = j;
            }
        }
        return currentMaxIndex;
    }
}