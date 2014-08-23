namespace Stack
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
            MyStack<int> numbers = new MyStack<int>();
            for (int i = 0; i < 20; i++)
            {
                numbers.Push(i);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Deleted from stack - {0}", numbers.Pop());
            }

            // Display the stack
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            numbers.Clear();
            try
            {
                Console.WriteLine("Peek at top element: ");
                numbers.Peek();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
