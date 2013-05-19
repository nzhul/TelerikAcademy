// 05. Write program that asks for a digit and depending on the 
// input shows the name of that digit (in English) using a switch statement.

using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter a digit ( 0 to 9): ");
        byte digit = byte.Parse(Console.ReadLine());
        string digitName = "";
        switch (digit)
        {
            case 0:
                digitName = "Zero";
                break;
            case 1:
                digitName = "One";
                break;
            case 2:
                digitName = "Two";
                break;
            case 3:
                digitName = "Three";
                break;
            case 4:
                digitName = "Four";
                break;
            case 5:
                digitName = "Five";
                break;
            case 6:
                digitName = "Six";
                break;
            case 7:
                digitName = "Seven";
                break;
            case 8:
                digitName = "Eight";
                break;
            case 9:
                digitName = "Nine";
                break;
            default:
                Console.WriteLine("The value you have entered is INVALID!\nPlease enter a digit in the diapason of 0-9");
                break;
        }
        Console.WriteLine("The digit you have entered is {0}({1})", digitName, digit);
    }
}
