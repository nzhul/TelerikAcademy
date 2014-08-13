namespace RemoveAllNegatives
{
    using System;
    using System.Collections.Generic;
    class RemoveAllNegatives
    {
        static void Main()
        {
            List<int> numbers = new List<int>() { 1, 2, -3, -4, 5, 6 };

            Console.WriteLine("Initial Numbers: ");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + " ");
            }


            int numbersLen = numbers.Count;
            List<int> positiveNmbers = new List<int>();
            for (int i = 0; i < numbersLen; i++)
            {
                if (numbers[i] < 0)
                {
                    continue;
                }
                positiveNmbers.Add(numbers[i]);
            }

            Console.WriteLine("\nOnly Positive Numbers: ");
            for (int i = 0; i < positiveNmbers.Count; i++)
            {
                Console.Write(positiveNmbers[i] + " ");
            }
        }
    }
}
