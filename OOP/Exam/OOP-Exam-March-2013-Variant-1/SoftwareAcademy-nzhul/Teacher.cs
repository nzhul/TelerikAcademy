using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        private string _name;
        private ICollection<ICourse> _courses;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid Name");
                }
                _name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this._courses.Add(course);
        }

        public Teacher(string name)
        {
            this.Name = name;
            _courses = new List<ICourse>();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Teacher: ");
            builder.AppendFormat("Name={0}; ", this.Name);
            if (_courses.Count > 0)
            {
                builder.Append("Courses=[");
                //builder.Append(string.Join(", ", this._courses.Select(course => course.Name)));
                foreach (var course in _courses)
                {
                    builder.AppendFormat("{0}, ",course.Name);
                }
                builder.Length -= 2; // We delete the last two symbols from the builder ", "
                builder.Append("]");
            }
            return builder.ToString();
        }
    }
}
