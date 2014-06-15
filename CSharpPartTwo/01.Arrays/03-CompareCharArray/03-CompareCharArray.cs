//03. Write a program that compares two char arrays lexicographically (letter by letter).



using System;

class CharArrayCompare
{
    static void Main()
    {
        Console.Write("Enter the first char array as string: ");
        char[] firstArray = Console.ReadLine().ToCharArray();
        Console.Write("Enter the second char array as string: ");
        char[] secondArray = Console.ReadLine().ToCharArray();
        int loopLength;
        int smallerArray = 0;

        if (firstArray.Length >= secondArray.Length)
        {
            loopLength = secondArray.Length;
        }
        else
        {
            loopLength = firstArray.Length;
        }

        for (int i = 0; i < loopLength; i++)
        {
            if (firstArray[i] < secondArray[i])
            {
                smallerArray = 1;
                break;
            }
            else if (firstArray[i] > secondArray[i])
            {
                smallerArray = 2;
                break;
            }
        }

        if (smallerArray == 1)
        {
            Console.WriteLine("The first array is earlier.");
        }
        else if (smallerArray == 2)
        {
            Console.WriteLine("The second array is earlier.");
        }
        else
        {
            if (firstArray.Length > secondArray.Length)
            {
                Console.WriteLine("The second array is earlier.");
            }
            else if (firstArray.Length < secondArray.Length)
            {
                Console.WriteLine("The first array is earlier.");
            }
            else
            {
                Console.WriteLine("The two arrays are the same.");
            }
        }

    }
}
