using System;

class RandomClass
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Value {0}: {1}", i, rand.Next(100, 200) + 1 );
        }
    }
}
