using TeamOOP.Utilities;
using PersonModule.PersonDefinitions;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace PersonModule
{
    public class Teacher : Employee, ICourses
    {
        public Teacher(string firstName, 
            string lastName, 
            string egn, 
            ContractType contractType, 
            int id,
            decimal salary,
            int rating,
            TeacherRank rank=TeacherRank.Unknown)
                : base(firstName, 
                    lastName, 
                    egn, 
                    Position.Teacher, 
                    contractType, 
                    id, 
                    salary,
                    rating)
        {
            this.CoursesList = new List<Course>();
            this.rank = Rank; //!
        }

        //Property
        private List<Course> coursesList;
        public List<Course> CoursesList
        {
            get
            {
                List<Course> copy = new List<Course>(this.coursesList);
                return copy;
            }
            set
            {
                this.coursesList = value;
            }

        }

        //! and please check the toXML override
        private TeacherRank rank;
        public TeacherRank Rank
        {
            get
            {
                TeacherRank copy = this.rank;

                return copy;
            }
            set { this.rank = value; }
        }


        //Methods
        public void AddCourse(Course course)
        {
            this.CoursesList.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            this.CoursesList.Remove(course);
        }

        override public XElement toXML()
        {
            Teacher teacher = (Teacher)this;
            XElement teacherNode = new XElement("Teacher");
            teacherNode.Add(base.toXML());
            XElement coursesListNode = new XElement("CoursesList");
            foreach (var course in teacher.coursesList)
            {
                coursesListNode.Add(new XElement("Course", course.ToString()));
            }
            teacherNode.Add(coursesListNode);
            teacherNode.Add(new XElement("Rank", teacher.rank));
            return teacherNode;
        }

        public Teacher(XmlNode xmlNode)
            :base(
            xmlNode.SelectSingleNode("Employee/PresonalDetails/FirstName").InnerText,
            xmlNode.SelectSingleNode("Employee/PresonalDetails/LastName").InnerText,
            xmlNode.SelectSingleNode("Employee/PresonalDetails/EGN").InnerText,
            Position.Teacher,
            (ContractType)Enum.Parse(typeof(ContractType), xmlNode.SelectSingleNode("Employee/ContractType").InnerText),
            int.Parse(xmlNode.SelectSingleNode("Employee/ID").InnerText),
            decimal.Parse(xmlNode.SelectSingleNode("Employee/Salary").InnerText),
            int.Parse(xmlNode.SelectSingleNode("Employee/Rating").InnerText)
            )
        {
            TeacherRank rank = (TeacherRank)Enum.Parse(typeof(TeacherRank), xmlNode.SelectSingleNode("Rank").InnerText);
            this.Rank = rank;
            this.coursesList = new List<Course>();
            XmlNode coursesNode = xmlNode.SelectSingleNode("CoursesList");
            if (!(coursesNode == null))
            {
                XmlNode courseNode = coursesNode.FirstChild;
                while (!(courseNode == null))
                {
                    object cName = Enum.Parse(typeof(CourseName), courseNode.InnerText.ToString());
                    this.AddCourse(new Course((CourseName)cName));
                    courseNode = courseNode.NextSibling;
                }
            }
        }

    }
}
