namespace Company
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static int allSalaries = 0;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            Dictionary<string, Employee> employees = new Dictionary<string, Employee>();
            string bossName = Console.ReadLine();
            Employee theBigBoss = new Employee(bossName);

            employees.Add(bossName, theBigBoss);

            for (int i = 1; i < n; i++)
            {
                string currentName = Console.ReadLine();
                Employee currentEmployee = new Employee(currentName);
                employees.Add(currentName, currentEmployee);
            }

            for (int i = 0; i < m; i++)
            {
                string line = Console.ReadLine();
                string[] names = line.Split(' ');
                string superior = names[0];
                for (int j = 1; j < names.Length; j++)
                {
                    employees[superior].Subordinates.Add(employees[names[j]]);
                }
            }

            DFS(theBigBoss);
            Console.WriteLine(allSalaries);
            
        }

        public static void DFS(Employee root)
        {
            if (root.Subordinates.Count == 0)
            {
                allSalaries += root.Salary;
                return;
            }

            int salary = 0;
            foreach (var employee in root.Subordinates)
            {
                DFS(employee);
                salary += employee.Salary;
            }

            root.Salary = salary;
            allSalaries += root.Salary;
        }
    }
}
