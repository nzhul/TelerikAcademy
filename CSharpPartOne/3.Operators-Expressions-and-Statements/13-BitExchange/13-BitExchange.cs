// 13. Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

using System;

class ExchangeBitsFirst
{
    static void Main()
    {
        Console.Write("Enter a number to exchange bits 3, 4 and 5 with bits 24, 25 and 26: ");
        uint number = uint.Parse(Console.ReadLine()) ;
        uint mask = 1;
        uint bit1;
        uint bit2;
        uint number1;
        byte k = 3;
        byte p = 24;
        Console.WriteLine("{0} : Original number : {1} in decimal",Convert.ToString(number, 2).PadLeft(32, '0'), number);
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
        Console.WriteLine("{0} : Converted number : {1} in decimal", Convert.ToString(number, 2).PadLeft(32, '0'),number);
    }
}