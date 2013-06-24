using System;

    class ArrayX5
    {
        static void Main()
        {
            int[] numbers = new int[20];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i * 5;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("numbers[{0}] = {1}", i, numbers[i]);
            }
        }
    }