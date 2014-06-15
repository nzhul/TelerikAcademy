using System;

namespace GenericList
{
    class GenericListTest
    {
        static void Main()
        {
            GenericList<int> intList = new GenericList<int>();
            intList.AddElement(5);
            intList.AddElement(10);
            intList.AddElement(15);
            Console.WriteLine(intList);
            intList.InsertElementAt(1, 20);
            Console.WriteLine(intList);
            intList.RemoveElementAtIndex(2);
            Console.WriteLine(intList);
            intList.AddElement(50);
            intList.AddElement(60);
            Console.WriteLine(intList);
            Console.WriteLine("Elements Count: {0}", intList.Count);
            Console.WriteLine("Min: {0}", intList.Min());
            Console.WriteLine("Max: {0}", intList.Max());
            Console.WriteLine(new String('-', 30));
        }
    }
}
