// 02. Write a program that reads a string, reverses it and prints the result at the console.
//     Example: "sample"  "elpmas".


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
