// 01. Write a program that reads an integer number and calculates 
//     and prints its square root. If the number is invalid or negative, 
//     print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.


using System;

class SimpleExeption
{
    static void Main()
    {
        try
        {
            Console.Write("Enter n: ");
            uint n = uint.Parse(Console.ReadLine());
            Console.WriteLine(Math.Sqrt(n));
        }
        catch (ArgumentException)
        {

            Console.WriteLine("Invalid number (Ctrl+Z)");
        }
        catch (FormatException)
        {

            Console.WriteLine("Invalid number - NaN");
        }
        catch (OverflowException)
        {

            Console.WriteLine("Invalid number - Number too Big!");
        }
        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}