// 04. Sort 3 real values in descending order using nested if statements.

using System;

class SortValues
{
    static void Main()
    {
        Console.Write("Number a:");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Number b:");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Number c:");
        int c = int.Parse(Console.ReadLine());

        if (a > b)
        {
            if (a > c)
            {
                if (b > c)
                {
                    Console.WriteLine("{0}\n{1}\n{2}", a, b, c);
                }
                else
                {
                    Console.WriteLine("{0}\n{1}\n{2}", a, c, b);
                }
            }
            else
            {
                Console.WriteLine("{0}\n{1}\n{2}", c, a, b);
            }
        }
        else if (b > c)
        {
            if (a > c)
            {
                Console.WriteLine("{0}\n{1}\n{2}", b, a, c);
            }
            else
            {
                Console.WriteLine("{0}\n{1}\n{2}", b, c, a);
            }
        }
        else
        {
            Console.WriteLine("{0}\n{1}\n{2}", c, b, a);
        }
        Console.WriteLine();


        // Solution using arrays
        int[] numbersArray = new int[] { a, b, c };
        Array.Sort(numbersArray);
        Array.Reverse(numbersArray);

        foreach (int number in numbersArray)
        {
            Console.WriteLine(number);
        }
    }
}

// The second solution is way more flexible
// You can have infinite number of numbers and the solution will still work.