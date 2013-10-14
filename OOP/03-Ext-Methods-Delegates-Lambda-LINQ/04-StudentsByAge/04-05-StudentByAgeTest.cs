// 04. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
// 05. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order. Rewrite the same with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;

class StudentByAgeTest
{
    public static IEnumerable<Student> FindByAge(Student[] students)
    {
        var result = from student in students
                     where student.Age >= 18 && student.Age <= 24
                     select student;
        return result;
    }
    static void Main()
    {
        Student[] students = new Student[5];
        students[0] = new Student("Dobromir", "Ivanov", 18);
        students[1] = new Student("Serafim", "Jichkov", 9);
        students[2] = new Student("Evdoki", "Malinov", 35);
        students[3] = new Student("Pesho", "Petrov", 22);
        students[4] = new Student("Gosho", "Georgiev", 23);

        var searchedStudents = FindByAge(students);
        Console.WriteLine("Printing Students limited by age:");
        foreach (var student in searchedStudents)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine("\nPrinting sorted students:");
        var sortedStudents = students.OrderByDescending(m => m.FirstName).ThenByDescending(m => m.LastName);
        foreach (var student in sortedStudents)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine("\nPrinting sorted students with LINQ:");
        var sortedStudentsLINQ = from student in students
                             orderby student.FirstName descending, student.LastName descending
                             select student;
        foreach (var student in sortedStudentsLINQ)
        {
            Console.WriteLine(student);
        }
    }
}
