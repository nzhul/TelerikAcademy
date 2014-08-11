namespace SortList
{
    using System;
    using System.Collections.Generic;

    public class SortList
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

            inputValues.Sort();
            Console.WriteLine("The sorted List Looks like this: ");
            for (int i = 0; i < inputValues.Count; i++)
            {
                Console.Write(inputValues[i] + ", ");
            }
        }
    }
}
