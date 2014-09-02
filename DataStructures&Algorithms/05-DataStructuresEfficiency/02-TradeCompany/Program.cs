namespace TradeCompany
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
            OrderedMultiDictionary<double, Article> articles = new OrderedMultiDictionary<double, Article>(true);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string line;
            using (StreamReader reader = new StreamReader(@".../../data.csv"))
            {
                line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] content = line.Split(new char[] {',','"'}, StringSplitOptions.RemoveEmptyEntries);
                    string barcode = content[0];
                    string vendor = content[1];
                    string title = content[2];
                    double price = Double.Parse(content[3]);
                    Article currentArticle = new Article(barcode, vendor, title, price);
                    if (articles.ContainsKey(currentArticle.Price))
                    {
                        articles[currentArticle.Price].Add(currentArticle);
                    }
                    else
                    {
                        articles.Add(currentArticle.Price, currentArticle);
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine("Create and Add 15 000 Articles: {0}", stopwatch.Elapsed);

            stopwatch.Reset();
            stopwatch.Restart();

            var result = articles.Range(1234.0, true, 13456.0, true);
            stopwatch.Stop();
            Console.WriteLine("Search: {0}", stopwatch.Elapsed);
            Console.WriteLine(result.Count);
        }
    }
}
