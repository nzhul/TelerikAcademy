// 10. Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. Example: v=5; p=1  false.

using System;

class BitPosition
{
    static void Main()
    {
        Console.Write("Please enter the number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Please enter the bit position: ");
        int bitPosition = int.Parse(Console.ReadLine()); // Insert 3 for 3th bit;
        int mask = 1;
        mask = mask << bitPosition;

        int addMask = number & mask;

        if (addMask != 0)
        {
            Console.WriteLine("The bit in position {0} is 1", bitPosition);
        }
        else
        {
            Console.WriteLine("The bit in position {0} is 0", bitPosition); // It isn't 1 
        }


        // Those lines of code helps to understand the bitwise operation
        string numberBinary = Convert.ToString(number, 2);
        string maskBinary = Convert.ToString(mask, 2);
        string addMaskBinary = Convert.ToString(addMask, 2);

        Console.WriteLine("{0,15} : number\n{1,15} : mask\n{2,15} : addMask", numberBinary, maskBinary, addMaskBinary);

    }
}

// I will just copy/paste the code from exercise 5, because it completes the same task.