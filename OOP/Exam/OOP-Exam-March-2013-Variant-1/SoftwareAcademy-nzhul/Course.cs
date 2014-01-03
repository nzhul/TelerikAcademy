using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        private string _name;
        private ICollection<string> _topics;

        protected Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            _topics = new List<string>();
        }

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

        public ITeacher Teacher
        { get; set; }

        public void AddTopic(string topic)
        {
            _topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0}: Name={1}", this.GetType().Name, this.Name);
            if (this.Teacher != null)
            {
                builder.AppendFormat("; Teacher={0}", this.Teacher.Name);
            }
            if (_topics.Count > 0)
            {
                builder.AppendFormat("; Topics=[{0}]", string.Join(", ", _topics));
            }
            return builder.ToString();
        }
    }
}
