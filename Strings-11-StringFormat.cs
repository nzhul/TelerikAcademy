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
