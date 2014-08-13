namespace Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Occurrences
    {
        public static void Main()
        {
            List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

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

            Console.WriteLine("\nOccurrances: ");
            foreach (var number in occurrences)
            {
                Console.Write("\nNumber: " + number.Key + "; Occurrences: " + number.Value);
            }
            Console.ReadLine();
        }
    }
}
