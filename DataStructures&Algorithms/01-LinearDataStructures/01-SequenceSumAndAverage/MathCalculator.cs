namespace SequenceSumAndAverage
{
    using System;
    using System.Collections.Generic;

    public class MathCalculator
    {
        public static int Sum(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("The list cannot be empty!");
            }

            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }

        public static double Average(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("The list cannot be empty!");
            }

            double average;
            double listCount = numbers.Count;
            double sum = Sum(numbers);

            average = sum / listCount;
            return average;
        }
    }
}
