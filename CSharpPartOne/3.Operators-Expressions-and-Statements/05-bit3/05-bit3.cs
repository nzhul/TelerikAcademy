// 05. Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

using System;

class bit3
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
            Console.WriteLine("The bit in position {0} is 1",bitPosition);
        }
        else {
            Console.WriteLine("The bit in position {0} is 0",bitPosition); // It isn't 1 
        }


        // Those lines of code helps to understand the bitwise operation
        string numberBinary = Convert.ToString(number, 2);
        string maskBinary = Convert.ToString(mask, 2);
        string addMaskBinary = Convert.ToString(addMask, 2);

        Console.WriteLine("{0,15} : number\n{1,15} : mask\n{2,15} : addMask", numberBinary, maskBinary, addMaskBinary);

    }
}

// The idea behind this solution is that we use mask to compare the bits of the number with the bits of a number that contain only one bit that is true ( 1 )
// for example if we need to check if the 5th bit of the number 485 is 1. then we must create a mask that has only one bit with 1 and that bit is at 5th position.
// we do that by using mask << 5 (the mask must start from 0001).
// if we convert the number and the mask into binary we have this output:
//  111100101 : number 485
//  000100000 : mask (this is the number 32)
//  000100000 : bitwise "AND" result
// Then we can check if the "AND" result is NOT 0. that means that the bit is 1