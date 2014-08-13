namespace Majorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Majorant
    {
        public static void Main()
        {
            List<int> numbers = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            Console.WriteLine("Initial Numbers: ");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

            Dictionary<int, int> occurrences = new Dictionary<int, int>();

            foreach (int number in numbers)
            {
                if (occurrences.ContainsKey(number))
                {
                    occurrences[number] += 1;
                }
                else
                {
                    occurrences.Add(number, 1);
                }
            }

            int listLength = numbers.Count;
            double majorantThreshold = listLength / 2 + 1;
            int theMajorant = 0;
            foreach (var number in occurrences)
            {
                if (number.Value >= majorantThreshold)
                {
                    theMajorant = number.Key;
                }
            }
            Console.WriteLine("\nMajorant: " + theMajorant);
            Console.ReadLine();
        }
    }
}
