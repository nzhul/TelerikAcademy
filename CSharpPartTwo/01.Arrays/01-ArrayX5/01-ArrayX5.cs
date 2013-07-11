//01. Write a program that allocates array of 20 integers and 
//    initializes each element by its index multiplied by 5. Print the obtained array on the console.


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