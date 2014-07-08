using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonModule.PersonDefinitions
{
    public class Course
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Course(CourseName name)
        {
            this._name = name.ToString();
        }

        public override string ToString()
        {
            return this._name;
        }
    }
}
