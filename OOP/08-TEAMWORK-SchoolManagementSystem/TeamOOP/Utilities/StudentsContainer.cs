using PersonModule;
using PersonModule.PersonDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TeamOOP.Utilities
{
    public class StudentsContainer : IFunctions
    {
        #region Properties
        private List<Student> studentList;
        public List<Student> StudentList
        {
            get 
            {
                return new List<Student>(this.studentList);
            }
            private set { }

        }
        #endregion

        #region Constructor (Singleton)
        private static StudentsContainer instance;

        private StudentsContainer() 
        {
            this.studentList = new List<Student>();
        }

        public static StudentsContainer Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new StudentsContainer();
                }
                return instance;
            }
        }
        #endregion

        #region API
        public void Add(Person student)
        {
            Student inputParse = (Student)student;

            if (this.studentList.Any(x => x.EGN == student.EGN))
            {
                throw new InvalidOperationException("Attempt to add student with already existing EGN");
            }

            this.studentList.Add(inputParse);
        }
                
        public void Remove(string egn)
        {
            if (egn == null)
	        {
		        throw new ArgumentNullException();
	        }

            if (!this.studentList.Any(x => x.EGN == egn))        
            {
                throw new InvalidCastException("Attempt to remove nonexistent student.");
            }

            this.studentList.RemoveAll(x => x.EGN == egn);
        }

        public void Remove(int facNum)
        {
            if (facNum <= 0)
            {
                throw new ArgumentException();
            }

            if (!this.studentList.Any(x => x.FacultyNumber == facNum))
            {
                throw new InvalidOperationException("Attempt to remove nonexistent employee.");
            }

            this.studentList.RemoveAll(x => x.FacultyNumber == facNum);
        }

        public void ClearStudentsList()
        {
            this.studentList.Clear();
        }

        public IEnumerable<Student> SortByAlphabeticalOrderFName()
        {
            var sorted = this.studentList.OrderBy(x => x.FirstName[0]);
            return sorted;
        }

        public IEnumerable<Student> SortByAlphabeticalOrderLName()
        {
            var sorted = this.studentList.OrderBy(x => x.LastName[0]);
            return sorted;
        }

        public string StudentCounter()
        {
            return StudentList.Count().ToString();
        }

        public double AverageGrade()
        {
            double averGradeSum = 0;
            double studCount = StudentList.Count();
            foreach (var item in StudentList)
            {
                if (item.AverageGrade == 0)
                {
                    studCount--;
                }
                averGradeSum+=item.AverageGrade;
            }

            return (averGradeSum/studCount);
        }

        public Student BestStudent()
        {
            Student bestStudent = StudentList.Aggregate((i1, i2) => i1.TotalPoints > i2.TotalPoints ? i1 : i2);
            return bestStudent;
        }

        public void ReadStudentsFromFile(string fileName)
        {
            XmlDocument XMLData = new XmlDocument();
            XMLData.Load(fileName);

            StudentsContainer students = StudentsContainer.Instance;
            XmlNode studentsNode = XMLData.SelectSingleNode("//ListOfStudents");
            XmlNode studentNode = studentsNode.FirstChild;
            while (!(studentNode == null))
            {
                students.Add(new Student(studentNode));
                studentNode = studentNode.NextSibling;
            }
        }
        #endregion

        public void FillWithDummyData()
        {
            studentList.Clear();
            studentList.Add(new Student("Иван", "Иванов", "1887375473", 33365, StudentRank.Bachelor, "Враца"));
            studentList.Add(new Student("Стамат", "Георгиев", "2887375473", 33456, StudentRank.Doctor));
            studentList.Add(new Student("Димитричка", "Трендафилова", "3887375473", 33456, StudentRank.Junior, "Пловдив"));
            studentList.Add(new Student("Григор", "Димитров", "4887375473", 33465, StudentRank.Junior));
            studentList.Add(new Student("Йозев", "Юрумов", "5887375473", 33487, StudentRank.Junior, "София"));
            studentList.Add(new Student("Кристиан", "Узунов", "6887375473", 33135, StudentRank.Junior, "Видин"));
            studentList.Add(new Student("Глория", "Петкова", "7887375473", 33457));
            studentList[0].AddCourse(new Course(CourseName.Chemistry));
            studentList[0].AddGrade(new Grade(4, new Course(CourseName.Chemistry)));
            studentList[0].AddGrade(new Grade(3, new Course(CourseName.Chemistry)));
        }
    }
}
