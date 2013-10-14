// 03. Write a method that from a given array of students finds all students whose first 
//     name is before its last name alphabetically. Use LINQ query operators.


using System;
using System.Linq;
using System.Collections.Generic;

class Test
{
    public static IEnumerable<Student> FindByName(Student[] students)
    {
        var result = from student in students
                     where student.FirstName.CompareTo(student.LastName) < 0
                     select student;
        return result;
    }

    static void Main()
    {
        Student[] students = new Student[5];
        students[0] = new Student("Dobromir", "Ivanov");
        students[1] = new Student("Serafim", "Jichkov");
        students[2] = new Student("Evdoki", "Malinov");
        students[3] = new Student("Pesho", "Petrov");
        students[4] = new Student("Gosho", "Georgiev");

        var searchedStudents = FindByName(students);
        foreach (var student in searchedStudents)
        {
            Console.WriteLine(student);
        }
    }
}