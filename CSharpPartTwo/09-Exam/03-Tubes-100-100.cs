using System;

class Tubes
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        long m = long.Parse(Console.ReadLine());
        long[] tubes = new long[n];
        for (int i = 0; i < n; i++)
        {
            tubes[i] = int.Parse(Console.ReadLine());
        }

        long maxTube = 0;
        for (int i = 0; i < tubes.Length; i++)
        {
            if (tubes[i] > maxTube)
            {
                maxTube = tubes[i];
            }
        }
        long finalResult = -1;
        long left = 1;
        long right = maxTube;
        long middle = (left + right) / 2;

        while (left <= right)
        {
            long eventual = 0;
            for (int j = 0; j < tubes.Length; j++)
            {
                eventual += tubes[j] / middle;
            }
            if (eventual < m)
            {
                right = middle - 1;
            }
            else if (eventual >= m)
            {
                left = middle + 1;
                finalResult = middle;
            }

            middle = (left + right) / 2;
        }
        Console.WriteLine(finalResult);
    }
}
