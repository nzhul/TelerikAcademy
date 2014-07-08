using System;


class SandGlass
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int astericsCount = n;
        int dotCount = 0;

        for (int i = 0; i < n; i++)
        {
            string drawDots = new string('.', dotCount);
            string drawAsterics = new string('*', astericsCount);
            Console.WriteLine(drawDots + drawAsterics + drawDots);
            dotCount += 1;
            if (astericsCount == 1)
            {
                break;
            }
            astericsCount -= 2;
        }

        dotCount -= 2;
        astericsCount += 2;
        for (int i = 0; i < n; i++)
        {
            string drawDots = new string('.', dotCount);
            string drawAsterics = new string('*', astericsCount);
            Console.WriteLine(drawDots + drawAsterics + drawDots);
            dotCount -= 1;
            if (astericsCount == n)
            {
                break;
            }
            astericsCount += 2;
        }
    }
}