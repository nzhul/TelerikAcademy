using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_PhoneBook
{
    class Program
    {
        static void Main()
        {
            Phone phone = new Phone();

            string line;
            using (StreamReader reader = new StreamReader("../../phones.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] content = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    PhoneEntry entry = new PhoneEntry(content[0].Trim(), content[1].Trim(), content[2]);
                    phone.Add(entry.Name, entry);
                }
            }

            var searchByName = phone.Find("Mimi Shmatkata");
            foreach (var value in searchByName)
            {
                Console.WriteLine("{0} | {1} | {2}", value.Name, value.City, value.Number);
            }

            var searchByNameAndCity = phone.Find("Mimi Shmatkata", "Varna");
            foreach (var value in searchByNameAndCity)
            {
                Console.WriteLine("{0} | {1} | {2}", value.Name, value.City, value.Number);
            }
        }
    }
}
