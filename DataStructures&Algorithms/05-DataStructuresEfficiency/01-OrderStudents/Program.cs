namespace DataStructuresEfficiency
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
            SortedDictionary<string, OrderedBag<Student>> students = new SortedDictionary<string, OrderedBag<Student>>();

            string line;
            using (StreamReader reader = new StreamReader(@"../../students.txt"))
            {
                while ((line = reader.ReadLine())!= null)
                {
                    string[] content = line.Split(new char[]{'|'}, StringSplitOptions.RemoveEmptyEntries);
                    Student currentStudent = new Student(content[0].Trim(), content[1].Trim(), content[2]);
                    if (students.ContainsKey(currentStudent.Course))
                    {
                        students[currentStudent.Course].Add(currentStudent);
                    }
                    else
                    {
                        students.Add(currentStudent.Course, new OrderedBag<Student>() { currentStudent });
                    }
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine("{0}: {1}", student.Key, string.Join(", ", student.Value));
            }
        }
    }
}
