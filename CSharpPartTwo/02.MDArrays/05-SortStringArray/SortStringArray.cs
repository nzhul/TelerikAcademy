// 05. You are given an array of strings. Write a method that sorts the array 
// by the length of its elements (the number of characters composing them).


using System;

class SortStringArray
{
    static void Main()
    {
        //string[] strings = { "12", "12345", "123456", "1", "1234", "123" };
        string[] strings = { "azmodan", "belial", "mephisto", "diablo", "assassin", "monk" };
        SortingMethod(strings);
        foreach (var item in strings)
        {
            Console.WriteLine(item);
        }
    }

    static void SortingMethod(string[] array)
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

//Сортирането става на база този overload на метода Array.Sort: http://msdn.microsoft.com/en-us/library/aa311214(v=vs.71).aspx
//Sorts a pair of one-dimensional Array objects (one contains the keys and the other contains the corresponding items)
//based on the keys in the first Array using the IComparable interface implemented by each key.

//Или накратко сортирането става чрез два масива: първия са indexите по които искаме до сортираме, а втория е самия масив който искаме да се сортира.