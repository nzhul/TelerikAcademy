namespace StackReverse
{
    using System;
    using System.Collections.Generic;
    public class StackReverse
    {
        public static void Main()
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter number " + i + ": ");
                int parsedNumber;
                if (int.TryParse(Console.ReadLine(), out parsedNumber))
                {
                    numbers.Push(parsedNumber);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            Console.WriteLine("The numbers reversed: ");
            int numbersCount = numbers.Count;
            for (int i = 0; i < numbersCount; i++)
            {
                Console.Write(numbers.Pop() + ", ");
            }
        }
    }
}
