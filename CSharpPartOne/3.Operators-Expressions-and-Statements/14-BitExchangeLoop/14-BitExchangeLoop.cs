// 14. * Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

using System;

class ExchangeBitsFirst
{
    static void Main()
    {
        Console.Write("Enter a number to exchange bits: ");
        uint number = uint.Parse(Console.ReadLine());
        uint mask = 1;
        uint bit1;
        uint bit2;
        uint number1;
        Console.Write("Now enter the starting lower bit: ");
        byte k = byte.Parse(Console.ReadLine());
        Console.Write("Now enter the starting higher bit: ");
        byte p = byte.Parse(Console.ReadLine());
        Console.WriteLine("{0} : Original number : {1} in decimal", Convert.ToString(number, 2).PadLeft(32, '0'), number);
        for (byte i = 1; i <= 3; i++, k++, p++)
        {
            mask = mask << k;
            bit1 = (mask & number) >> k;
            mask = mask >> k;
            mask = mask << p;
            bit2 = (mask & number) >> p;
            mask >>= p;
            if (bit1 != bit2)
            {
                if (bit1 == 1)
                {
                    number1 = number | (mask << p);
                    number = number1 ^ (mask << k);
                }
                else
                {
                    number1 = number ^ (mask << p);
                    number = number1 | (mask << k);
                }
            }
        }
        Console.WriteLine("{0} : Converted number : {1} in decimal", Convert.ToString(number, 2).PadLeft(32, '0'), number);
    }
}