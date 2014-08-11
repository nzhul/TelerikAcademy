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

            // TODO: Finish me

        }
    }
}
