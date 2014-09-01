using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class Program
    {
        static void Main()
        {
            PriorityQueue<int, string> pq = new PriorityQueue<int, string>();
            pq.Enqueue(38, "Pesho");
            pq.Enqueue(22, "Peshev");
            pq.Enqueue(65, "Misho");
            pq.Enqueue(-3, "Mishka");
            Console.WriteLine(pq.Dequeue());
            pq.Enqueue(8, "Mishle");

            while (pq.Count > 0)
            {
                Console.WriteLine(pq.Dequeue());
            }
        }
    }
}
