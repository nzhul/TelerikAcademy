// 05. Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

using System;

class bit3
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int mask = 8;
        //mask = mask << 3;

        int addMask = number & mask;

        if (addMask != 0)
        {
            Console.WriteLine("The 3th bit is 1");
        }
        else {
            Console.WriteLine("The 3th bit is 0"); // It isn't 1 
        }


        // Those lines of code helps to understand the bitwise operation
        string numberBinary = Convert.ToString(number, 2);
        string maskBinary = Convert.ToString(mask, 2);
        string addMaskBinary = Convert.ToString(addMask, 2);

        Console.WriteLine("{0} : number\n{1} : mask\n{2} : addMask", numberBinary, maskBinary, addMaskBinary);

    }
}
