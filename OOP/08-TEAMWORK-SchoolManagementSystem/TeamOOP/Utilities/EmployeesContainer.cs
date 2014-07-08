using PersonModule;
using PersonModule.PersonDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TeamOOP.Utilities
{
    public class EmployeesContainer : IFunctions
    {
        #region Properties
        private List<Employee> employeesList;
        public List<Employee> EmployeesList
        {
            get 
            {
                //return copy of list
                return new List<Employee>(this.employeesList);
            }
            private set { }

        }

         public decimal TotalSalaryCost
        {
            get
            {
                decimal totalSalary = 0;
                for (int i = 0; i < EmployeesList.Count; i++)
                {
                    totalSalary += EmployeesList[i].Salary;
                }
                return totalSalary;
            }
        }

         public decimal AverageSalary
         {
             get
             {
                 decimal averageSlaray = TotalSalaryCost;

                 return averageSlaray / employeesList.Count;
             }
         }
        #endregion

        #region Constructor (Singleton)
        private static EmployeesContainer instance;

        private EmployeesContainer() 
        {
            this.employeesList = new List<Employee>();
        }

        public static EmployeesContainer Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new EmployeesContainer();
                }
                return instance;
            }
        }
        #endregion

        #region API
        public void Add(Person employee)
        {
            Employee inputParse = (Employee)employee;

            if (this.employeesList.Any(x => x.Id == inputParse.Id))
            {
                throw new InvalidOperationException("Attempt to add employee with already existing id");
            }

            if (this.employeesList.Any(x => x.EGN == employee.EGN))
            {
                throw new InvalidOperationException("Attempt to add employee with already existing EGN");
            }

            this.employeesList.Add(inputParse);
        }

        public void Remove(string egn)
        {
            if (egn == null)
	        {
		        throw new ArgumentNullException();
	        }

            if (!this.employeesList.Any(x => x.EGN == egn))        
            {
                throw new InvalidCastException("Attempt to remove nonexistent employee.");
            }

            //this will remove only one object
            this.employeesList.RemoveAll(x => x.EGN == egn);
        }

        public void Remove(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }

            if (!this.employeesList.Any(x => x.Id == id))
            {
                throw new InvalidOperationException("Attempt to remove nonexistent employee.");
            }

            //this will remove only one object
            this.employeesList.RemoveAll(x => x.Id == id);
        }

        public void ClearEmployeesList()
        {
            this.employeesList.Clear();
        }

        public IEnumerable<Employee> GetSortedBySalary()
        {
            var sorted = this.employeesList.OrderBy(x => x.Salary);
            return sorted;
        }

        public void ReadEmployeesFromFile(string fileName)
        {
            XmlDocument XMLData = new XmlDocument();
            XMLData.Load(fileName);

            EmployeesContainer employees = EmployeesContainer.Instance;
            XmlNode employeesNode = XMLData.SelectSingleNode("//ListOfEmployees");
            XmlNode employeeNode = employeesNode.FirstChild;
            while (!(employeeNode == null))
            {
                switch (employeeNode.Name.ToString())
                {
                    case "Teacher":
                        employees.Add(new Teacher(employeeNode));
                        break;
                    case "Administrator":
                        employees.Add(new Administrator(employeeNode));
                        break;
                    case "Hygenist":
                        employees.Add(new Hygienist(employeeNode));
                        break;
                    case "Principal":
                        employees.Add(new Principal(employeeNode));
                        break;
                }
                employeeNode = employeeNode.NextSibling;
            }
        }

        public Employee BestEmployee()
        {
            Employee bestEmployee = EmployeesList.Aggregate((i1, i2) => i1.Salary > i2.Salary ? i1 : i2);
            return bestEmployee;
        }
        #endregion
        
        public void FillWithDummyData()
        {
            employeesList.Clear();
            employeesList.Add(new Principal("Даскал", "Даскалов", "65854895", ContractType.Infinite, 1, 2555, 0));
            employeesList.Add(new Teacher("Johnatan", "Smith", "78654987", ContractType.OneYear, 2, 1222, 0));
            employeesList.Add(new Teacher("Станимир", "Добринов", "558877946", ContractType.ThreeYears, 3, 1222, 0));
            employeesList.Add(new Administrator("Божидар", "Красимиров", "65874689", ContractType.ThreeYears, 4, 1888, 0));
            employeesList.Add(new Hygienist("Lelia", "Ver4e", "00", ContractType.Infinite, 5, 777, 0));

        }
    }
}
