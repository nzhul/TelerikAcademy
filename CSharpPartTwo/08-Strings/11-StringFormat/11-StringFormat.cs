// 11. Write a program that reads a number and prints it as a decimal number,
//     hexadecimal number, percentage and in scientific notation. Format the 
//     output aligned right in 15 symbols.

using System;

class StringFormat
{
    static void Main()
    {
        float input = float.Parse(Console.ReadLine());
        Console.WriteLine("{0,15}: Decimal", input);
        Console.WriteLine("{0,15:X}: Hex", (int)input);
        Console.WriteLine("{0,15:P}: Percent", input); // 0.5 = 50%; 0.05 = 5%;
        Console.WriteLine("{0,15:E}: Scientific Notation", input);
    }
}
