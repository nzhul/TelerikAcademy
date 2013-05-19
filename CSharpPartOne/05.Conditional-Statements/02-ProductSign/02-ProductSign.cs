// 02. Write a program that shows the sign (+ or -) of the product of 
// three real numbers without calculating it. Use a sequence of if statements.

using System;

class ProductSign
{
    static void Main()
    {
        int a = 5;
        int b = 2;
        int c = -6;

        if (a < 0 || b < 0 || c < 0)
        {
            Console.WriteLine("The sign of the product is NEGATIVE (-), because one or more of the numbers are negative!");
        }
        else
        {
            Console.WriteLine("The sign of the product is POSITIVE (+), because none of the numbers are negative!");
        }
    }
}

// If we have only one negative number - the product of the multiplication will be negative!