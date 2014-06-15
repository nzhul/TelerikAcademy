// 04. Write a method that counts how many times given number appears in given array. 
//     Write a test program to check if the method is working correctly.


using System;
using System.Linq;

class NumberCount
{
    static void Main()
    {
        int[] numbers = { -2, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3, 4 };
        int searchedNumber = 4;
        int asd = numbers.Max();

        int count = FindNumberCount(numbers, searchedNumber);
        Console.WriteLine(count);
    }

    static int FindNumberCount(int[] numbers, int searchedNumber)
    {
        int counter = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == searchedNumber)
            {
                counter++;
            }
        }
        return counter;
    }
}
