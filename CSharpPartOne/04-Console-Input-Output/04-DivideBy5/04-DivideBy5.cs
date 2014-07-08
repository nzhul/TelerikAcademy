// 04. Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

using System;

class DivideBy5
{
    static void Main()
    {
        Console.Write("Smaller Number (a): ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Bigger number (b): ");
        int b = int.Parse(Console.ReadLine());

        if (a < b)
        {
            int count = 0;
            for (int i = a; i <= b; i++)
            {
                if (i % 5 == 0)
                {
                    count++;
                }
            }
            Console.WriteLine("The number count is: {0}",count);
        }
        else
        {
            Console.WriteLine("Please Enter Valid Numbers! \"a\" must be < than \"b\"");
        }
    }
}
