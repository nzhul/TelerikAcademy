namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Program
    {
        static void Main()
        {
            Person gosho = new Person("Gosheto", 18);
            gosho.AddGrade(5);
            gosho.AddGrade(12);
            gosho.AddGrade(23);
            gosho.AddGrade(45);

            for (int i = 0; i < gosho.GradeList.Count; i++)
            {
                Console.WriteLine(gosho.GradeList[i]);
            }
        }
    }
}
