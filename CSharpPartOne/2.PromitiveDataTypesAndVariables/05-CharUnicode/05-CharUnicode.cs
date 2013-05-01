// 5. Declare a character variable and assign it with the symbol that has Unicode code 72. Hint: first use the Windows Calculator to find the hexadecimal representation of 72.

using System;


class CharUnicode
{
    static void Main()
    {
        int decNumber = 72;
        string HexNumber = "0x00" + decNumber.ToString("X");
        char unicodeChar = (char)0x0048; // trqbva da namerq nachin da oburna HexNumber vav Char
        Console.WriteLine("The symbol that represents the value {0} or {1} in the Unicode table is: {2}",decNumber,HexNumber,unicodeChar);
    }
}

