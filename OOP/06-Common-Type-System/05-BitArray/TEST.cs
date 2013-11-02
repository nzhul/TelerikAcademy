using System;

public class Program
{
    public static void Main()
    {
        BitArray64 myTestBitArray = new BitArray64(1546878);
        foreach (var item in myTestBitArray)
        {
            Console.Write("{0}", item);
        }
    }
}