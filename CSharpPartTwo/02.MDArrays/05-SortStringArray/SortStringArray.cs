using System;

class SortStringArray
{
    static void Main()
    {
        string[] strings = { "12", "12345", "123456", "1", "1234", "123" };
        string[] sortedArray = SortingMethod(ref strings);

        foreach (var item in sortedArray)
        {
            Console.WriteLine(item);
        }
    }

    static string[] SortingMethod(ref string[] array)
    {
        string[] sortedArray = (string[])array.Clone();
        Array.Sort(sortedArray);
        return sortedArray;
    }
}
