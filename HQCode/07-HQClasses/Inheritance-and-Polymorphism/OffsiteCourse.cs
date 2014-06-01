using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
    class OffsiteCourse : Course
    {
        public string Town { get; set; }

        public OffsiteCourse(string name, string teacher = "", IList<string> students = null)
            : base(name, teacher, students)
        {
            return;
        }

        public override string ToString()
        {
            return this.ToStringHelper(new KeyValuePair<string, string>("Town", this.Town));
        }
    }
}