// FOREST ROAD

using System;

class ForestRoad
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        // string direction = "right";

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (c == r)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }

        for (int rr = 1; rr < n; rr++)
        {
            for (int cc = n - 1; cc >= 0; cc--)
            {
                if (cc == rr)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
}