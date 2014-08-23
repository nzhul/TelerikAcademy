namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            LinkedList<int> numbers = new LinkedList<int>();
            for (int i = 0; i < 20; i++)
            {
                numbers.AddLast(i);
            }

            numbers.AddFirst(100);
            numbers.AddFirst(50);
            numbers.AddAfter(numbers.FirstElement, -50);

            foreach (var number in numbers)
            {
                System.Console.WriteLine(number);
            }
        }
    }
}
