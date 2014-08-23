namespace Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Program
    {
        static void Main()
        {
            MyQueue<int> numbers = new MyQueue<int>();

            for (int i = 1; i < 5; i++)
            {
                numbers.Enqueue(i);
            }
            int firstElement = numbers.Peek();
            Console.WriteLine(firstElement);

            // There is some bug with the dequeue that i need to find
            // numbers.Dequeue();

            try
            {
                foreach (var number in numbers)
                {
                    Console.WriteLine(number);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
        }
    }
}
