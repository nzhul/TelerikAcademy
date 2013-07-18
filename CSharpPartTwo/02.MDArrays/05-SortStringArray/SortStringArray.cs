using System;
class SortStringArray
{
    static void Main()
    {
        //string[] strings = { "12", "12345", "123456", "1", "1234", "123" };
        string[] strings = { "azmodan", "belial", "mephisto", "diablo", "assassin", "monk" };
        SortingMethod(ref strings);
        foreach (var item in strings)
        {
            Console.WriteLine(item);
        }
    }

    static void SortingMethod(ref string[] array)
    {
        int[] stringsLenghts = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            stringsLenghts[i] = array[i].Length;
        }
       Array.Sort(stringsLenghts, array);
       return;
    }
}
