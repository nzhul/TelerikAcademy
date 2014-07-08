using System;

class Carpets
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int dotsCount = (n / 2) - 1;
        
        for (int i = 0; i < n / 2; i++)
        {
            int remainingChars = (n / 2) - dotsCount;
            string drawDots = new String('.', dotsCount);
            Console.Write(drawDots);
            for (int j = 0; j < remainingChars; j++)
            {
                if (j % 2 == 0)
                {
                    Console.Write("/");   
                }
                else
                {
                    Console.Write(" ");
                }
            }
            for (int z = remainingChars + 1; z > 1; z--)
            {
                if (z % 2 == 0)
                {
                    Console.Write("\\");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.Write(drawDots);

            dotsCount--;
            Console.WriteLine();
        }

        dotsCount++;

        for (int i = 0; i < n / 2; i++)
        {
            int remainingChars = (n / 2) - dotsCount;
            string drawDots = new String('.', dotsCount);
            Console.Write(drawDots);
            for (int j = 0; j < remainingChars; j++)
            {
                if (j % 2 == 0)
                {
                    Console.Write("\\");   
                }
                else
                {
                    Console.Write(" ");
                }
            }
            for (int z = remainingChars + 1; z > 1; z--)
            {
                if (z % 2 == 0)
                {
                    Console.Write("/");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.Write(drawDots);

            dotsCount++;
            Console.WriteLine();
        }
    }
}
