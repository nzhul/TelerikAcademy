// 02. Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

using System;

class NotDivisible
{
    static void Main()
    {
        Console.Write("Enter the N number: ");
        int number = int.Parse(Console.ReadLine());

        for (int i = 1; i <= number; i++)
        {
            if (!(i % (3 * 7) == 0))
            {
                Console.WriteLine(i);
            }
        }
    }
}