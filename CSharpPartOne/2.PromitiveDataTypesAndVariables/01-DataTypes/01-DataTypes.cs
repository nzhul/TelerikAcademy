// 1. Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, short, ushort, int, uint, long, ulong to represent the following values: 52130, -115, 4825932, 97, -10000.

using System;


class DataTypes
{
    static void Main()
    {
        byte var1 = 97; // because the number is lower than 127
        sbyte var2 = -115; // because the number is between -128 and +128
        short var3 = -10000; // because the number is between -32768 and +32767
        ushort var4 = 52130; // because the number is between 0 and 65535
        int var5 = 4825932; // because the number is between -2147483648 and +2147483647

        Console.WriteLine("Print the variables: {0} {1} {2} {3} {4}", var1, var2, var3, var4, var5);
    }
}
