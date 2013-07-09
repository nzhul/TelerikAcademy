using System;

class SubsetSum
{
    static void Main()
    {
        int s = int.Parse(Console.ReadLine());
        int[] numbers = { 5, -2, -1, 1, 2, 3, 4 };

        int maxI = 1;
        for (int i = 1; i <= numbers.Length; i++)
        {
            maxI *= 2;
        }
        maxI -= 1;
        // maxI = (int)Math.Pow((double)2, numbers.Length) - 1;
        int count = 0;
        for (int i = 1; i <= maxI; i++)
        {
            int currentSum = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                int mask = 1 << j;
                int nAndMask = i & mask;
                int bit = nAndMask >> j;
                if (bit == 1)
                {
                    currentSum += numbers[j];
                }
            }
            if (currentSum == s)
            {
                // YES
                count++;
            }
        }
        Console.WriteLine(count);
    }
}