//02. Implement a set of extension methods for IEnumerable<T> that implement the 
//    following group functions: sum, product, min, max, average.


using System;

class IEnumerableExtensionsTests
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        Console.WriteLine("Sum: {0}", numbers.Sum());
        Console.WriteLine("Product: {0}", numbers.Product());
        Console.WriteLine("Min: {0}", numbers.Min());
        Console.WriteLine("Max: {0}", numbers.Max());
        Console.WriteLine("Average: {0}", numbers.Average());
    }
}
