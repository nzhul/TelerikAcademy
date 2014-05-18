using System;

class Program
{
    // const int MaxCount = 6;

    class BooleanPrinter
    {
        public void Print(bool boolean)
        {
            string booleanString = boolean.ToString();

            Console.WriteLine(booleanString);
        }
    }

    static void Main()
    {
        BooleanPrinter booleanPrinter = new BooleanPrinter();

        booleanPrinter.Print(true);
    }
}