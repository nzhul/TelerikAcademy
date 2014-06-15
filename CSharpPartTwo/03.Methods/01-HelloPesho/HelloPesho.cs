// 01. Write a method that asks the user for 
//     his name and prints “Hello, <name>” (for example, “Hello, Peter!”). 
//     Write a program to test this method.


using System;

class HelloPesho
{
    static void Main()
    {
        PrintName();
    }

    static void PrintName()
    {
        Console.Write("Enter your name: ");
        Console.WriteLine("Hello {0}", Console.ReadLine());
    }
}