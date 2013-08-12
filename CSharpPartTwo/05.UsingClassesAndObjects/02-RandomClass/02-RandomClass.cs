// 02. Write a program that generates and prints to the 
//     console 10 random values in the range [100, 200].


using System;

class RandomClass
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Value {0}: {1}", i, rand.Next(100, 200) + 1);
        }
    }
}