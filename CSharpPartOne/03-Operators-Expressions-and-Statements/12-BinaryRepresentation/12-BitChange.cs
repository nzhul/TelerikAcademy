// 12. We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
//	   Example: n = 5 (00000101), p=3, v=1  13 (00001101)
//	   n = 5 (00000101), p=2, v=0  1 (00000001)


using System;

class BitChange
{
    static void Main()
    {
        Console.Write("Please enter the number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Please enter the bit position: ");
        int bitPosition = int.Parse(Console.ReadLine());
        Console.Write("Enter the value to change (1 or 0): ");
        byte v = byte.Parse(Console.ReadLine());
        int mask = 1;
        mask = mask << bitPosition;

        if (v == 0)
        {
            int newNumber = (~(mask) & number); // we inverse the mask with ~(mask)
            Console.WriteLine("\nThe result is {0} - decimal {1}\n", Convert.ToString(newNumber, 2), newNumber);

            // Explanation
            string numberBinary = Convert.ToString(number, 2).PadLeft(32, '0');
            string maskBinary = Convert.ToString(~mask, 2).PadLeft(32, '0');
            string newNumberBinary = Convert.ToString(newNumber, 2).PadLeft(32, '0');
            Console.WriteLine("{0} : Original Number\n{1} : Inversed Mask\n{2} : New Number", numberBinary, maskBinary, newNumberBinary);
            // Explanation
        }
        else
        {
            int newNumber = (mask | number);
            Console.WriteLine("The result is {0} - decimal {1}", Convert.ToString(newNumber, 2), newNumber);

            // Explanation
            string numberBinary = Convert.ToString(number, 2).PadLeft(32, '0');
            string maskBinary = Convert.ToString(mask, 2).PadLeft(32, '0');
            string newNumberBinary = Convert.ToString(newNumber, 2).PadLeft(32, '0');
            Console.WriteLine("{0} : Original Number\n{1} : Mask\n{2} : New Number", numberBinary, maskBinary, newNumberBinary);
            // Explanation
        }
    }
}

// 