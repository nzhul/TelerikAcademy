namespace LongestSubSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LongestSubSequence
    {
        public static void Main()
        {
            Console.Write("Enter N: ");
            int numbersLength = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();

            for (int i = 0; i < numbersLength; i++)
            {
                Console.Write("Enter number " + i + ": ");
                int parsedNumber;
                if (int.TryParse(Console.ReadLine(), out parsedNumber))
                {
                    numbers.Add(parsedNumber);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }


            int currentSequence = 1;
            int maxSequence = 0;
            int sequenceDigit = 0;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    currentSequence++;
                }
                else
                {
                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                        sequenceDigit = numbers[i];
                    }
                    currentSequence = 1;
                }
            }

            //Special Case
            if (currentSequence > maxSequence)
            {
                maxSequence = currentSequence;
                sequenceDigit = numbers[numbers.Count - 1];
            }

            // Display the maximum sequence
            Console.WriteLine("The input sequence is: ");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine("\n-----------------");

            Console.WriteLine("The longest subsequence is: ");
            for (int i = 0; i < maxSequence; i++)
            {
                Console.Write(sequenceDigit + " ");
            }
        }
    }
}
