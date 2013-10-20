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
