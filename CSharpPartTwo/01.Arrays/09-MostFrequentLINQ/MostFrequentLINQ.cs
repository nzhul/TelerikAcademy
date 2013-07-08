//09. Write a program that finds the most frequent number in an array. Example:
//    {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

using System;
using System.Linq;

class MostFrequentLINQ
{
    static void Main()
    {
        int[] numbers = { -2, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3, };
        int mode = numbers.GroupBy(v => v).OrderByDescending(g => g.Count()).First().Key;
        Console.WriteLine(mode);
    }
}
