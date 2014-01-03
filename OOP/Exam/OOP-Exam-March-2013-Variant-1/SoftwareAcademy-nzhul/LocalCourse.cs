using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class LocalCourse : Course, ILocalCourse
    {
        private string _lab;

        public LocalCourse(string name, ITeacher teacher, string lab)
            :base(name,teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return _lab;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid Name");
                }
                _lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(base.ToString());
            builder.AppendFormat("; Lab={0}", this.Lab);
            return builder.ToString();
        }
    }
}
