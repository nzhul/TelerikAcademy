// 01 
// We are given a school. In the school there are classes of students. Each class has a set
// of teachers. Each teacher teaches a set of disciplines. Students have name and unique 
// class number. Classes have unique text identifier. Teachers have name. Disciplines 
// have name, number of lectures and number of exercises. Both teachers and 
// students are people. Students, classes, teachers and disciplines could 
// have optional comments (free text block).
// Your task is to identify the classes (in terms of  OOP) and their attributes and operations, 
// encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.


using System;

class TEST
{
    static void Main()
    {
        SchoolClass PHPClass = new SchoolClass();

        Teacher firstTeacher = new Teacher("Ivan Vankov");
        PHPClass.AddTeacher(firstTeacher);

        Teacher secondTeacher = new Teacher("Stamat Trendafilov");
        PHPClass.AddTeacher(secondTeacher);

        Student newStudent = new Student("Dobromir Ivanov", "756A");
        PHPClass.AddStudent(newStudent);

        Console.WriteLine("List of all teachers: ");
        foreach (Human teacher in PHPClass.ClassTeachersList)
        {
            Console.WriteLine(teacher);
        }

        Console.WriteLine("\nList of all Students: ");
        foreach (Human student in PHPClass.ClassStudentsList)
        {
            Console.WriteLine(student);
        }
    }
}
