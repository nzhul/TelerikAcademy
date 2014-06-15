// 65/100 in bgcoder

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dictionary
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int titleCount = int.Parse(Console.ReadLine());
            Dictionary<string, int> ranks = new Dictionary<string, int>();
            // Read Titles
            for (int i = 0; i < titleCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (!ranks.ContainsKey(tokens[0]))
                {
                    ranks.Add(tokens[0].Trim(), int.Parse(tokens[1].Trim()));
                }
            }
            //Read names
            List<Person> people = new List<Person>();
            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string[] names = tokens[0].Trim().Split(' ');
                Person person = new Person() { FirstName = names[0], LastName = names[1], Value = ranks[tokens[1].Trim()] };

                if (!people.Any(p => p.FirstName == person.FirstName && p.LastName == person.LastName))
                {
                    people.Add(person);
                }
            }

            people = people.OrderByDescending(x => x.Value).ThenBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            foreach (var person in people)
            {
                Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
            }
        }
    }
}