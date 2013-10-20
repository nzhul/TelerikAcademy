using System;
using System.Collections.Generic;
using System.Linq;

class TEST
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        students.Add(new Student("Zakero", "Tabayashi", 5.5));
        students.Add(new Student("Atanast", "Atanasov", 2.0));
        students.Add(new Student("Viktor", "Georgiev", 2.1));
        students.Add(new Student("Krustio", "Piskov", 4.1));
        students.Add(new Student("Svetlin", "Stanchev", 2.5));
        students.Add(new Student("Boyan", "Krastev", 5.1));
        students.Add(new Student("Yurii", "Seizmov", 4.2));
        students.Add(new Student("Nikolay", "Georgiev", 3.7));
        students.Add(new Student("Joro", "Ivanov", 4.9));
        students.Add(new Student("Cvetan", "Asenov", 3.5));

        List<Worker> workers = new List<Worker>();
        workers.Add(new Worker("John_", "Stanford", 1354, 16));
        workers.Add(new Worker("Stann_", "Lee", 7834, 24));
        workers.Add(new Worker("George_", "Martin", 4568, 6));
        workers.Add(new Worker("Charles_", "Dickens", 4355, 12));
        workers.Add(new Worker("Arthas_", "Menethil", 3324, 12));
        workers.Add(new Worker("Math_", "LeBlanc", 1123, 2));
        workers.Add(new Worker("Al_", "Capone", 1548, 5));
        workers.Add(new Worker("Al_", "Pacino", 8436, 10));
        workers.Add(new Worker("Malfurion_", "StormRage", 9565, 10));
        workers.Add(new Worker("Illidan_", "StormRage", 9670, 9));

        var sortedStudents = students.OrderBy(x => x.Grade);
        Console.WriteLine("Students by grade: ");
        foreach (Student student in sortedStudents)
        {
            Console.WriteLine(student);
        }
        Console.WriteLine(new String('-', 30));
        Console.WriteLine();

        Console.WriteLine("Workers by earnings per hour:");
        var sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour());
        foreach (Worker worker in sortedWorkers)
        {
            Console.WriteLine(worker);
        }
        Console.WriteLine(new String('-', 30));
        Console.WriteLine();

        List<Human> mergedList = new List<Human>();
        mergedList.AddRange(sortedStudents);
        mergedList.AddRange(sortedWorkers);
        var finalSort = mergedList.OrderBy(x => x.Firstname).ThenBy(x => x.LastName);

        Console.WriteLine("Printing all humans sorted by name: ");
        foreach (Human human in finalSort)
        {
            Console.WriteLine(human);
        }
    }
}
