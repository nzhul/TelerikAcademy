using System;


class MaximalSequence
{
    static void Main()
    {
        int[] numbers = {2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
        int maxSequence = 0;
        int currentSequence = 0;
        int SequenceNumber = 0;

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] == numbers[i + 1])
            {
                currentSequence++;
            }
            else
            {
                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                    SequenceNumber = numbers[i];
                }
                currentSequence = 1;
            }
        }

        // Special case
        if (currentSequence > maxSequence)
        {
            maxSequence = currentSequence;
            SequenceNumber = numbers[numbers.Length - 1];
        }

        // Display the maximum sequence
        Console.WriteLine("The input sequence is:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }
        Console.WriteLine();
        Console.WriteLine("The maximum sequence is: ");
        for (int i = 0; i < maxSequence; i++)
        {
            Console.Write("{0} ", SequenceNumber);
        }
    }
}