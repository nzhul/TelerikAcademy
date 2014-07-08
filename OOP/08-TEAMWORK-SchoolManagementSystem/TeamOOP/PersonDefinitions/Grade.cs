using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamOOP.Utilities;

namespace PersonModule.PersonDefinitions
{
    public class Grade : IStorable <Grade>
    {
        // This constant must be the weight of the course.
        // Each course has different weight. Ex: Mathematics(250) and Sports(60).
        // For now it is just hardcoded
        private const int courseWeight = 125;

        private double _weight;
        public double Weight 
        {
            get
            {
                return this._weight;
            }
            set 
            {
                if (value < 1.5)
                {
                    throw new ArgumentException("The min Value of the Grade is 1.5!");
                }
                if (value > 6.5)
                {
                    throw new ArgumentException("The max value of the Grade is 6.5!");
                }
                this._weight = value;
            }
        }

        public int Points 
        {
            get
            {
                return (int)(this._weight * courseWeight);
            }
        }
        public Course Course { get; set; }
        public DateTime Date { get; set; }

        public Grade(double weight, Course course)
        {
            this.Weight = weight;
            this.Course = course;
            // this.Points = (int)(weight * courseWeight); BETTER NOT ADD PROPERTY THAT CAN BE CALCULATED FROM THE GIVEN DATA. I AM SORRY I CHANGED YOUR CODE
            this.Date = DateTime.Now;
        }

        // This is needed only for binding!
        public string StringRepresentation {
            get
            {
                return this.ToString();
            }
        }

        public override string ToString()
        {
            // A B C D F
            // F- F F+ D- D D+ C- C C+ B- B B+ A- A A+
            // I know it is hardcoded but there is no other reasonable way to do it :)
            if (this.Weight >= 1.5 && this.Weight <= 1.9)
            {
                return "F-";
            }
            else if (this.Weight == 2.0)
            {
                return "F";
            }
            else if (this.Weight >= 2.1 && this.Weight <= 2.4)
            {
                return "F+";
            }
            else if (this.Weight >= 2.5 && this.Weight <= 2.9)
            {
                return "D-";
            }
            else if (this.Weight == 3.0)
            {
                return "D";
            }
            else if (this.Weight >= 3.1 && this.Weight <= 3.4)
            {
                return "D+";
            }
            else if (this.Weight >= 3.5 && this.Weight <= 3.9)
            {
                return "C-";
            }
            else if (this.Weight == 4.0)
            {
                return "C";
            }
            else if (this.Weight >= 4.1 && this.Weight <= 4.4)
            {
                return "C+";
            }
            else if (this.Weight >= 4.5 && this.Weight <= 4.9)
            {
                return "B-";
            }
            else if (this.Weight == 5.0)
            {
                return "B";
            }
            else if (this.Weight >= 5.1 && this.Weight <= 5.4)
            {
                return "B+";
            }
            else if (this.Weight >= 5.5 && this.Weight <= 5.9)
            {
                return "A-";
            }
            else if (this.Weight == 6.0)
            {
                return "A";
            }
            else if (this.Weight >= 6.1 && this.Weight <= 6.5)
            {
                return "A+";
            }
            else
            {
                return "A?";
            }
        }

        public XElement toXML()
        {
            var grade = this;
            XElement gradeNode = new XElement("Grade");
            gradeNode.Add(new XElement("Course", grade.Course));
            gradeNode.Add(new XElement("Date", grade.Date));
            gradeNode.Add(new XElement("Weight", grade.Weight));
            return gradeNode;
        }

        public Grade createFromXML(XElement xmlRecord)
        {
            throw new NotImplementedException();
        }
    }
}
