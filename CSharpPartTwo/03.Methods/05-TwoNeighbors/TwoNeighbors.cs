// 05. Write a method that checks if the element at given position in given array of 
//     integers is bigger than its two neighbors (when such exist).


using System;

class TwoNeighbors
{
    static void Main()
    {
        int[] numbers = { 2, 3, 5, 7, -2, 3, 1 };
        int index = 2;

        CheckNeighbors(numbers, index);
    }

    static void CheckNeighbors(int[] numbers, int index)
    {
        if (index - 1 < 0 || index + 1 > numbers.Length - 1)
        {
            Console.WriteLine("The element does not have left or right neighbor");
        }
        else
        {
            if (numbers[index - 1] < numbers[index] && numbers[index + 1] < numbers[index])
            {
                Console.WriteLine("The element IS bigger than its two neighbors!");
            }
            else
            {
                Console.WriteLine("The element IS NOT bigger than its two neighbors!");
            }
        }
    }
}