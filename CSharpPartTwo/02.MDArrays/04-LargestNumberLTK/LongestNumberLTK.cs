using System;

class LargestNumberLTK
{
    static void Main(string[] args)
    {
        //Console.Write("Enter N: ");
        //int n = int.Parse(Console.ReadLine());
        //int[] numbers = new int[n];
        //for (int i = 0; i < numbers.Length; i++)
        //    {
        //        Console.Write("Enter element [{0}]", i);
        //        numbers[i] = int.Parse(Console.ReadLine());
        //    }

        Console.Write("Enter Searched value (K): ");
        int k = int.Parse(Console.ReadLine());
        int[] numbers = { 6, 3, 2, 31, 15, 11, 5, 12, 5, 9 };


        Array.Sort(numbers);
        Console.WriteLine();

        // Print the sorted Array
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("{0, 2} ", i);
        }
        Console.WriteLine(" :Indexes");

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("{0, 2} ", numbers[i]);
        }
        Console.WriteLine(" :Values\n");

        int index = Array.BinarySearch(numbers, k);
        if (index == -1)
        {
            // The searched value is lower that all of the elements so there is no lower number
            // You can test that by entering "1" for K
            Console.Write("No such number! \n(The searched value is lower that all of\n the elements so there is no lower number)\n");            
        }
        else if (index < -1)
        {
            int realIndex = ~index - 1; // Ако пуснем само ~index това ще ни върне index-a но по-големия елемент, а ние търсим по-ламкия
            Console.WriteLine("The biggest number < than {0} is {1} with index of {2}", k, numbers[realIndex], realIndex);
        }
        else if (index >= 0)
        {
            Console.WriteLine("Number {0} exists in the array and has index of {1}", numbers[index], index);
        }
    }
}

// http://msdn.microsoft.com/en-us/library/2cy9f6wb.aspx
//Return Value
//Type: System.Int32
//The index of the specified value in the specified array, if value is found. 
//If value is not found and value is less than one or more elements in array, a 
//negative number which is the bitwise complement of the index of the first element 
//that is larger than value. If value is not found and value is greater than any of the 
//elements in array, a negative number which is the bitwise complement of (the index of the last element plus 1).