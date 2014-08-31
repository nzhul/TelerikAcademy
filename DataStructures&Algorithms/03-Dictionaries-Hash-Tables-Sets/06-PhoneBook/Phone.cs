using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _06_PhoneBook
{
    public class Phone
    {
        MultiDictionary<string, PhoneEntry> names = new MultiDictionary<string, PhoneEntry>(true);

        public void Add(string key, PhoneEntry value)
        {
            names.Add(key, value);
        }

        public ICollection<PhoneEntry> Find(string name)
        {
            return names[name];
        }

        public ICollection<PhoneEntry> Find(string name, string city)
        {
            ICollection<PhoneEntry> result = new Collection<PhoneEntry>();

            foreach (var n in names[name])
            {
                if (n.City == city)
                {
                    result.Add(n);
                }
            }
            return result;
        }
    }
}
