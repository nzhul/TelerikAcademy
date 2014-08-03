using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Person
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private List<int> gradeList;

        public List<int> GradeList
        {
            get { return gradeList; }
            private set { gradeList = value; }
        }



        public Person(string username, int age)
        {
            this.Username = username;
            this.Age = age;
            this.GradeList = new List<int>();
        }

        public void AddGrade(int grade)
        {
            this.GradeList.Add(grade);
        }
    }
}
