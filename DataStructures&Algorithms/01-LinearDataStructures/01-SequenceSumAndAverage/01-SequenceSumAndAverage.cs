namespace SequenceSumAndAverage
{
    using System;
    using System.Collections.Generic;
    public class SequenceSumAndAverage
    {
        public static void Main()
        {
            List<int> inputValues = new List<int>();
            bool isEndCommand = false;

            while (!isEndCommand)
            {
                Console.Write("Enter number: ");
                string inputLine = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(inputLine))
                {
                    isEndCommand = true;
                }
                else
                {
                    int parsedValue;
                    bool parseResult = int.TryParse(inputLine, out parsedValue);
                    if (parseResult && parsedValue > 0)
                    {
                        inputValues.Add(parsedValue);
                    }
                    else
                    {
                        Console.WriteLine("Invalid value - Please try again!");
                    }
                }
            }

            Console.WriteLine("The Sum of the values is: {0}", MathCalculator.Sum(inputValues));
            Console.WriteLine("The Average of the values is {0}", MathCalculator.Average(inputValues));
        }
    }
}
