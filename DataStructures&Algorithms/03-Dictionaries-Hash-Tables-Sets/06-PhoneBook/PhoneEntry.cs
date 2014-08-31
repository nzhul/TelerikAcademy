using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06_PhoneBook
{
    public class PhoneEntry
    {
        private string name = string.Empty;
        private string city = string.Empty;
        private string number = string.Empty;

        public PhoneEntry(string name, string city, string number)
        {
            this.Name = name;
            this.City = city;
            this.Number = number;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }
    }
}
