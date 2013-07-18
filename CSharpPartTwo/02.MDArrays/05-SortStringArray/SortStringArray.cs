using System;

class SortStringArray
{
    static void Main()
    {
        string[] strings = { "12", "12345", "123456", "1", "1234", "123" };
        strings = SortingMethod(ref strings);
        foreach (var item in strings)
        {
            Console.WriteLine(item);
        }
    }

    static string[] SortingMethod(ref string[] array)
    {
        Array.Sort(array);
        return array;
    }
}
