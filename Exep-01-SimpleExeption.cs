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

            Console.WriteLine("Invalid number");
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
