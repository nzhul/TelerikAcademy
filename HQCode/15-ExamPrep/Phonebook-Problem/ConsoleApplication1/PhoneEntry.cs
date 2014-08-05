namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhoneEntry : IComparable<PhoneEntry>
    {
        private string name; 
        private string nameForComparison;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.nameForComparison = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> PhoneNumbers;

        public override string ToString()
        {
            StringBuilder entryToString = new StringBuilder(); 
            entryToString.Append('[');
            entryToString.Append(this.Name);
            bool isFirstPhoneNumber = true;
            foreach (var phone in this.PhoneNumbers)
            {
                if (isFirstPhoneNumber)
                {
                    entryToString.Append(": ");
                    isFirstPhoneNumber = false;
                }
                else
                {
                    entryToString.Append(", ");
                }
                entryToString.Append(phone);
            }
            entryToString.Append(']');
            return entryToString.ToString();
        }

        public int CompareTo(PhoneEntry other)
        {
            return this.nameForComparison.CompareTo(other.nameForComparison);
        }
    }
}
