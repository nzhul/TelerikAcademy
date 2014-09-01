namespace LargeCollection
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class Program
    {
        private static readonly Random getRandom = new Random();
        private static readonly object syncLock = new object();

        static void Main()
        {
            OrderedBag<Product> products = new OrderedBag<Product>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 1; i < 500000; i++)
            {
                Product p = new Product();
                p.Name = "Prodcut" + i;
                p.Price = GetRandomNumber(35, 599) * i * GetRandomNumber(3, 5) / GetRandomNumber(2, 4);
                products.Add(p);
            }

            stopwatch.Stop();
            Console.WriteLine("Create and Add 500k products: {0}", stopwatch.Elapsed);

            List<Product> prodRange = new List<Product>();
            stopwatch.Reset();
            stopwatch.Restart();

            for (int i = 1; i <= 10000; i++)
            {
                int min = GetRandomNumber(35, 599) * i * GetRandomNumber(3, 5) / GetRandomNumber(2, 4);
                int max = GetRandomNumber(35, 599) * i * 13 * GetRandomNumber(3, 5);

                prodRange.AddRange(products.Range(new Product() { Price = min }, true, new Product() { Price = max }, true).Take(20));
            }

            stopwatch.Stop();
            Console.WriteLine("Search for 10k random price ranges: {0}", stopwatch.Elapsed);
        }

        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getRandom.Next(min, max);
            }
        }
    }
}
