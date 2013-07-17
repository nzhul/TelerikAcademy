using System;

class GetMaxMethod
{
    static void Main()
    {
        Console.Write("Enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter c: ");
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine("The maximum number is: {0}", GetMax(GetMax(a, b), c));
    }

    static int GetMax(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
}