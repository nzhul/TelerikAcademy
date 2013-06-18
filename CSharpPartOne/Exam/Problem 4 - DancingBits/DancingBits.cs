using System;
using System.Text;

class DancingBits
{
    static void Main()
    {
        int k = Int32.Parse(Console.ReadLine());
        int n = Int32.Parse(Console.ReadLine());

        StringBuilder finalString = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            finalString.Append(Convert.ToString(int.Parse(Console.ReadLine()), 2));
        }

        for (int i = 0; i < finalString.Length; i++)
        {

        }


    }
}