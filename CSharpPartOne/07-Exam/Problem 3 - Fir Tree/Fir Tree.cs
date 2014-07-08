using System;


class FirTree
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int rows = n;
        int dots = n - 1;
        int increment = 0;

        for (int r = 1; r < rows; r++)
        {
            int dotsCount = dots - r;
            string drawDots = new string('.', dotsCount);
            int asteriskCount = r + increment;
            string drawAsterisk = new string('*', asteriskCount);
            Console.WriteLine(drawDots + drawAsterisk + drawDots);
            increment += 1;
        }
        string drawDots2 = new string('.', dots - 1);
        string drawAsterisk2 = new string('*', 1);
        Console.WriteLine(drawDots2 + drawAsterisk2 + drawDots2);

    }
}
