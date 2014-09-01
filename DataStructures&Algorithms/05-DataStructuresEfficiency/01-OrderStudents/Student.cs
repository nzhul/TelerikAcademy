using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresEfficiency
{
    class Student : IComparable<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }

        public Student(string firstName, string lastName, string course)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Course = course;
        }
        
        public int CompareTo(Student other)
        {
            if (this.FirstName != other.FirstName)
            {
                return StringComparer.CurrentCulture.Compare(this.FirstName, other.FirstName);
            }
            else if (this.LastName != other.LastName)
            {
                return StringComparer.CurrentCulture.Compare(this.LastName, other.LastName);
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}
