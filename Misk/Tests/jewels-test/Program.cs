using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jewels_test
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("#");
                }
                Console.Write(" ");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }
    }
}
