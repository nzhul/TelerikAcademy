namespace BiDictionary
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
            var bidict = new BiDictionary<string, int, string>(allowDuplicateValues: true);

            bidict.Add("pesho", 1, "JavaScript");
            bidict.Add("gosho", 2, "Java");
            bidict.Add("nakov", 3, "C#");
            bidict.Add("nakov", 3, "C#");
            bidict.Add("gosho", 3, "Coffee");
            bidict.Add("nakov", 1, "Python");

            Console.WriteLine(string.Join(" ", bidict.GetByFirstKey("nakov")));
            Console.WriteLine(string.Join(" ", bidict.GetBySecondKey(3)));
            Console.WriteLine(string.Join(" ", bidict.GetByFirstAndSecondKey("nakov", 3)));

            Console.WriteLine(bidict.Count);

            bidict.RemoveByFirstKey("gosho");
            Console.WriteLine(bidict.Count);

            bidict.RemoveBySecondKey(3);
            Console.WriteLine(bidict.Count);

            bidict.RemoveByFirstAndSecondKey("nakov", 1);
            Console.WriteLine(bidict.Count);


        }
    }
}
