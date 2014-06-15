using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
    class LocalCourse : Course
    {
        public string Lab { get; set; }

        public LocalCourse(string name, string teacher = "", IList<string> students = null)
            : base(name, teacher, students)
        {
            return;
        }

        public override string ToString()
        {
            return this.ToStringHelper(new KeyValuePair<string, string>("Lab", this.Lab));
        }
    }
}