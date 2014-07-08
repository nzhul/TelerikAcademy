using System;


class Trapezoid
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int emptyCellsCount = n;
        int fullCellsCount = n;
        string emptyCells = new String('.', emptyCellsCount);
        string fullCells = new String('*', fullCellsCount);
        Console.WriteLine(emptyCells + fullCells);
        for (int r = 2; r <= n; r++)
        {
            int dotsCount = n - r + 1;
            int rightDotsCount = n - 1 + r - 2;
            string leftDots = new String('.', dotsCount);
            string rightDots = new String('.', rightDotsCount);
            Console.WriteLine(leftDots + '*' + rightDots + '*');
        }
        fullCells = new String('*', 2 * n);
        Console.WriteLine(fullCells);
    }
}
