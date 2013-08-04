using System;

class StringSum
{
    static void Main()
    {
        Console.WriteLine("Enter numbers separated by space ' ': ");
        string[] numbers = Console.ReadLine().Trim().Split();
        int sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += int.Parse(numbers[i]);
        }

        Console.WriteLine("The sum is: {0}", sum);
    }
}
