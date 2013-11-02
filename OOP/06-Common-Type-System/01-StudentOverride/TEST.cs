using System;
using System.Collections.Generic;

namespace StudentOverride
{
    class TEST
    {
        static void Main()
        {
            Student gosho = new Student("Georgi", "Nikolov", "Ivanov", "1415A687", "Sofia Mladost 5", "asddd@abv.bg", "0088795");
            Student pesho = new Student("Petar", "Nikolov", "Ivanov", "AASF323", "Vraca 234", "hjfjf@gmail.com", "35687",
                Universities.NewBulgarianUniversity, Faculties.GameProgramming, Specialties.Javascript);
            Console.WriteLine(pesho);
            Student stamat = new Student("Stamat", "Todorov", "Spiridonov", "DDS##$F", "Varna 54", "stamat@abv.bg", "04897487",
                Universities.UNSS, Faculties.WebProgramming, Specialties.PHP);

            Console.WriteLine("Student Comparison");
            Console.WriteLine(gosho != pesho);
            Console.WriteLine(gosho == pesho);
            Console.WriteLine(gosho.Equals(pesho));

            var peshoClone = gosho.Clone();
            Console.WriteLine("\nPrinting Pesho Colone:");
            Console.WriteLine(peshoClone);


            // We are able to sort the student list because of the implementation of IComparable Interface!
            Console.WriteLine("\n\nSorting and Foreaching student List");
            List<Student> students = new List<Student>();
            
            students.Add(pesho);
            students.Add(gosho);
            students.Add(stamat);

            students.Sort();
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
