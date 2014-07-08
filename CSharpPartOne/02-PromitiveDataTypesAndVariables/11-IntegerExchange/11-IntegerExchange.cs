// 11. Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.


using System;


class IntegerExchange
{
    static void Main()
    {
        // This can be done by using 3th variable
        int a = 5;
        int b = 10;
        int c;

        c = a;
        a = b;
        b = c;

        Console.WriteLine("Original Value:\na = 5\nb = 10\n\nNew Value:\na = {0}\nb = {1}", a, b);


        // Or without using 3th variable. The problem with this 2nd method is that it can cause overflow if the variables contain too big integers
        a = 5;
        b = 10;

        a = a + b;
        b = a - b;
        a = a - b;

        Console.WriteLine("Original Value:\na = 5\nb = 10\n\nNew Value:\na = {0}\nb = {1}", a, b);

    }
}

