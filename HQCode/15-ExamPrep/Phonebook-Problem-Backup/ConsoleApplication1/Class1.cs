namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Class1 : IComparable<Class1>
    {
        private string name; 
        private string name2;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.name2 = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> Strings;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(); 
            sb.Clear(); 
            sb.Append('[');
            sb.Append(this.Name);
            bool flag = true;
            foreach (var phone in this.Strings)
            {
                if (flag)
                {
                    sb.Append(": ");
                    flag = false;
                }
                else
                {
                    sb.Append(", ");
                }
                sb.Append(phone);
            }
            sb.Append(']');
            return sb.ToString();
        }

        public int CompareTo(Class1 other)
        {
            return this.name2.CompareTo(other.name2);
        }
    }
}
