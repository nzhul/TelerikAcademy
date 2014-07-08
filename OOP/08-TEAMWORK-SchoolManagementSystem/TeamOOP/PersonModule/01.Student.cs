using TeamOOP.Utilities;
using PersonModule.PersonDefinitions;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace PersonModule
{
    public class Student : Person, ICourses
    {
        public int FacultyNumber { get; private set; }
        public Course _bestCourse;
        private List<Course> coursesList;
        private StudentRank _rank;
        private List<Grade> _gradeList;

        public List<Grade> GradeList
        {
            get
            {
                //return copy
                List<Grade> copy = new List<Grade>(this._gradeList);
                return copy;
            }
            set
            {
                this._gradeList = value;
            }
        }
        

        public StudentRank Rank
        {
        //    get { return _rank; }
        //    set { _rank = value; }

            get
            {
                StudentRank copy = this._rank;

                return copy;
            }
            set { this._rank = value; }
        }
        

        public List<Course> CoursesList
        {
            get
            {
                //return copy
                List<Course> copy = new List<Course>(this.coursesList);
                return copy;
            }
            set 
            {
                this.coursesList = value;
            }

        }

        public double AverageGrade
        {
            get
            {
                double gradesSum = 0;
                int countGrades = GradeList.Count;
                if (countGrades != 0)
                {
                    for (int i = 0; i < GradeList.Count; i++)
                    {
                        gradesSum += GradeList[i].Weight;
                    }
                    return (gradesSum / countGrades);
                }
                else
                {
                    return 0;
                }
            }
        }

        public int TotalPoints 
        {
            get
            {
                int totalPoints = 0;
                for (int i = 0; i < GradeList.Count; i++)
                {
                    totalPoints += GradeList[i].Points;
                }
                return totalPoints;
            }
        }

        public Course BestCourse
        {
            get
            {
                // TODO: Implement it!
                return new Course(CourseName.Unknown);
            }
        }

        public Student(string firstName, string lastName, string egn, int facultyNumber, StudentRank rank = StudentRank.Unknown, string hometown = "Unknown")
            : base(firstName, lastName, egn, hometown)
        {
            //if (facultyNumber == null)
            //{
            //    throw new ArgumentNullException("Faculty number cannot be null");
            //}

            if (facultyNumber == 0)
            {
                throw new ArgumentException("Faculty number cannot be zero");
            }

            this.coursesList = new List<Course>();
            this.GradeList = new List<Grade>();
            this.FacultyNumber = facultyNumber;
            this.Rank = rank;
        }

        public void AddCourse(Course course)
        {
            this.coursesList.Add(course);
            //this.gradesList.Add(course, new List<double>()); // Is this needed? 
        }

        public void RemoveCourse(Course course)
        {
            this.CoursesList.Remove(course);
        }

        //public void AddGrade(Course course, double grade)
        //{
        //    if (this.GradesList.ContainsKey(course))
        //    {
        //        this.GradesList[course].Add(grade);
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Student does not attend this course!");
        //    }
        //}
        public void AddGrade(Grade grade)
        {
            this._gradeList.Add(grade);
        }

        override public XElement toXML()
        {
            Student student = (Student) this;
            XElement studentNode = new XElement("Student");
            studentNode.Add(base.toXML());
            XElement coursesListNode = new XElement("CoursesList");
            foreach (var course in student.coursesList)
            {
                coursesListNode.Add(new XElement ("Course",course));
            }
            studentNode.Add(coursesListNode);
            XElement gradesListNode = new XElement("GradesList");
            foreach (var grade in student._gradeList)
            {
                gradesListNode.Add(grade.toXML());
            }
            studentNode.Add(gradesListNode);
            studentNode.Add(new XElement("FacultyNumber", student.FacultyNumber));
            studentNode.Add(new XElement("Rank", student.Rank));
            //studentNode.Add(new XElement("Points", student.TotalPoints));
            return studentNode;
        }

        public Student(XmlNode xmlNode):base(
            xmlNode.SelectSingleNode("PresonalDetails/FirstName").InnerText,
            xmlNode.SelectSingleNode("PresonalDetails/LastName").InnerText,
            xmlNode.SelectSingleNode("PresonalDetails/EGN").InnerText,
            xmlNode.SelectSingleNode("PresonalDetails/HomeTown").InnerText
            )
        {
            int facultyNumber = int.Parse(xmlNode.SelectSingleNode("FacultyNumber").InnerText);
            StudentRank rank = (StudentRank)Enum.Parse(typeof(StudentRank), xmlNode.SelectSingleNode("Rank").InnerText);
            //int points = int.Parse(xmlNode.SelectSingleNode("Points").InnerText);

            if (facultyNumber == 0)
            {
                throw new ArgumentException("Faculty number cannot be zero");
            }
            this.coursesList = new List<Course>();
            XmlNode coursesNode = xmlNode.SelectSingleNode("CoursesList");
            XmlNode courseNode = coursesNode.FirstChild;
            while (!(courseNode == null))
            {

                
                //Enum.Parse(cName, courseNode.InnerText.ToString());

                object cName = Enum.Parse(typeof(CourseName), courseNode.InnerText.ToString());

                this.AddCourse (new Course((CourseName)cName));
                courseNode = courseNode.NextSibling;
            }

            this.GradeList = new List<Grade>();
            XmlNode gradesNode = xmlNode.SelectSingleNode("GradesList");
            XmlNode gradeNode = gradesNode.FirstChild;
            while (!(gradeNode == null))
            {
                this.AddGrade(new Grade(
                    double.Parse(gradeNode.SelectSingleNode("Weight").InnerText),
                    new Course((CourseName)Enum.Parse(typeof(CourseName), gradeNode.SelectSingleNode("Course").InnerText.ToString()))
                    )
                    );
                gradeNode = gradeNode.NextSibling;
            }

            this.FacultyNumber = facultyNumber;
            this.Rank = rank;
            //this.Points = points;
        }

        public void UpdateStudentDetails(string newFirstName, string newLastName, string newEGN, int newFacultyNumber, StudentRank newRank = StudentRank.Unknown, string newHometown = "Unknown")
        {
            this.UpdatePersonalDetails(newFirstName, newLastName, newEGN, newHometown);
            if (newFacultyNumber == 0)
            {
                throw new ArgumentException("Faculty number cannot be zero");
            }

    //        this.coursesList = new List<Course>();
    //        this.GradeList = new List<Grade>();
            this.FacultyNumber = newFacultyNumber;
            this.Rank = newRank;
            //this.Points = newPoints;
        }

    }
}
