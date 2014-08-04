namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    class REP : IPhonebookRepository
    {
        private OrderedSet<Class1> sorted = new OrderedSet<Class1>();
        private Dictionary<string, Class1> dict = new Dictionary<string, Class1>();
        private MultiDictionary<string, Class1> multidict = new MultiDictionary<string, Class1>(false);

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            string name2 = name.ToLowerInvariant();
            Class1 entry; bool flag = !this.dict.TryGetValue(name2, out entry);
            if (flag)
            {
                entry = new Class1(); entry.Name = name;
                entry.Strings = new SortedSet<string>(); this.dict.Add(name2, entry);
                this.sorted.Add(entry);
            }
            foreach (var num in nums)
            {
                this.multidict.Add(num, entry);
            }
            entry.Strings.UnionWith(nums);
            return flag;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.multidict[oldent].ToList(); 
            foreach (var entry in found)
            {
                entry.Strings.Remove(oldent);
                this.multidict.Remove(oldent, entry);
                entry.Strings.Add(newent); this.multidict.Add(newent, entry);
            }
            return found.Count;
        }

        public Class1[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.dict.Count)
            {
                Console.WriteLine("Invalid start index or count."); return null;
            }

            Class1[] list = new Class1[num];

            for (int i = first; i <= first + num - 1; i++)
            {
                Class1 entry = this.sorted[i];
                list[i - first] = entry;
            }
            return list;
        }
    }
}
