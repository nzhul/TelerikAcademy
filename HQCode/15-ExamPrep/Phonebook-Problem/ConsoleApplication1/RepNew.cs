namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class REPNew : IPhonebookRepository
    {
        public List<PhoneEntry> entries = new List<PhoneEntry>();

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            var old = from e in this.entries where e.Name.ToLowerInvariant() == name.ToLowerInvariant() select e;

            bool flag;
            if (old.Count() == 0)
            {
                PhoneEntry obj = new PhoneEntry(); 
                obj.Name = name;
                obj.Strings = new SortedSet<string>();

                foreach (var num in nums)
                {
                    obj.Strings.Add(num);
                }
                this.entries.Add(obj);
                
                flag = true;
            }
            else if (old.Count() == 1)
            {
                PhoneEntry obj2 = old.First();
                foreach (var num in nums)
                {
                    obj2.Strings.Add(num);
                } 
                
                flag = false;
            }
            else
            {
                Console.WriteLine("Duplicated name in the phonebook found: " + name);
                return false;
            }

            return flag;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var list = from e in this.entries where e.Strings.Contains(oldent) select e;

            int nums = 0;
            foreach (var entry in list)
            {
                entry.Strings.Remove(oldent); entry.Strings.Add(newent);
                nums++;
            }
            return nums;
        }

        public PhoneEntry[] ListEntries(int start, int num)
        {
            if (start < 0 || start + num > this.entries.Count)
            {   
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }
            this.entries.Sort();
            PhoneEntry[] ent = new PhoneEntry[num]; for (int i = start; i <= start + num - 1; i++)
            {
                PhoneEntry entry = this.entries[i];
                ent[i - start] = entry;
            }
            return ent;
        }
    }
}
