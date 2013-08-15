using System;

class ReverseString
{
    static void Main()
    {
        char[] input = Console.ReadLine().ToCharArray();
        Array.Reverse(input);
        Console.WriteLine(input); 
    }
}
