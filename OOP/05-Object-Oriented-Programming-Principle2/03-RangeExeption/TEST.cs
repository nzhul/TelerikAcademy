//03. Define a class InvalidRangeException<T> that holds information about an error condition 
//    related to invalid range. It should hold error message and a range definition [start … end].
//    Write a sample application that demonstrates the InvalidRangeException<int> and 
//    InvalidRangeException<DateTime> by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].


using System;

namespace RangeExeption
{
    class TEST
    {
        static void Main()
        {
            {
                try
                {
                    int start = 1;
                    int end = 100;

                    int x = 200;

                    if (!(start < x && x < end))
                    {
                        throw new InvalidRangeException<int>(start, end);
                    }
                }
                catch (InvalidRangeException<int> e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Start: {0}; End {1};", e.Start, e.End);
                }
            }

            Console.WriteLine();
            {
                try
                {
                    DateTime start = new DateTime(1988, 2, 3);
                    DateTime end = new DateTime(2013, 12, 31);

                    DateTime x = DateTime.MinValue;

                    if (!(start < x && x < end))
                    {
                        throw new InvalidRangeException<DateTime>(start, end);
                    }
                }
                catch (InvalidRangeException<DateTime> e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Start: {0}; End {1};", e.Start, e.End);
                }
            }
        }
    }
}
