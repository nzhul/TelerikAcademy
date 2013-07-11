//05. Write a program that finds the maximal increasing sequence in 
//    an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.


using System;


class MaxIncreasingSequence
{
    static void Main()
    {
        int[] numbers = {1, 2, 3, 4, 5, 6, 7, 2, 5, 6, 7, 8, 9, 10, 11, 12, 2, 3, 4, 4 };
        int maxSequence = 0;
        int currentSequence = 0;
        int sequenceEnd = 0;

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] + 1 == numbers[i + 1])
            {
                currentSequence++;
            }
            else
            {
                if (currentSequence > maxSequence)
                {
                    sequenceEnd = numbers[i];
                    maxSequence = currentSequence;
                }
                currentSequence = 1;
            }
        }

        // Special Case
        if (currentSequence > maxSequence)
        {
            maxSequence = currentSequence;
            sequenceEnd = numbers[numbers.Length - 1];
        }

        // Display the maximum sequence
        Console.WriteLine("The input sequence is:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }
        Console.WriteLine();
        Console.WriteLine("The maximum Increasing sequence is: ");
        for (int i = maxSequence - 1; i >= 0; i--)
        {
            Console.Write("{0} ", sequenceEnd - i);
        }
    }
}

// There is a problem if the sequence start from the 1st element. // TODO
