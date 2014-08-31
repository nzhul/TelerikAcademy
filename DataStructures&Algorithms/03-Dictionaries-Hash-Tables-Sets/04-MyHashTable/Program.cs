using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHashTable
{
    class Program
    {
        static void Main()
        {
            MyHashTable<string, int> ht = new MyHashTable<string, int>();

            ht.Add("Wizard", 10);
            ht.Add("Stronger", 20);

            ht["Barbarian"] = 12;
            ht["Warrior"] = 12;

            Console.WriteLine(ht["Wizard"]);
            ht["Wizard"] = 22;
            Console.WriteLine(string.Join(Environment.NewLine, ht));
        }
    }
}
