using PersonModule.PersonDefinitions;
using System;
using System.Xml.Linq;

namespace PersonModule
{
    public abstract class Employee : Person
    {
        private ContractType contractType;
        private int id;
        private decimal salary;
        private Position position;
        private int _rating;

        public int Rating
        {
            get { return _rating; }
            set 
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Invalid Rating Input");
                }
                _rating = value;
            }
        }
        
        

        public Position Position
        {
            get
            {
                //return copy
                Position copy = this.position;

                return copy;
            }
            set
            {
                this.position = value;
            }

        }

        public ContractType ContractType
        {
            get
            {
                ContractType copy = this.contractType;

                return copy;
            }
            set
            {
                this.contractType = value;
            }
        }

        public int Id
        {
            get
            {
                int copy = this.id;

                return copy;
            }
            set
            {
                this.id = value;
            }
        }

        public decimal Salary
        {
            get
            {
                decimal copy = this.salary;

                return copy;
            }
            set
            {
                this.salary = value;
            }
        }

        public Employee(string firstName, 
            string lastName, 
            string egn,
            Position position, 
            ContractType type,
            int id,
            decimal salary,
            int rating)
                :base(firstName,lastName,egn)
        {        
            if (id < 0)
            {
                throw new ArgumentException("Identification number cannot be negative");
            }

            if (salary < 0)
            {
                throw new ArgumentException("Salary cannot be negative");
            }

            this.Position = position;
            this.ContractType = type;
            this.Id = id;
            this.Salary = salary;
            this._rating = rating;
        }

        override public XElement toXML()
        {
            Employee employee = (Employee)this;
            XElement employeeNode = new XElement("Employee");
            employeeNode.Add(base.toXML());
            employeeNode.Add(new XElement("Position", employee.position));
            employeeNode.Add(new XElement("ContractType", employee.ContractType));
            employeeNode.Add(new XElement("ID", employee.id));
            employeeNode.Add(new XElement("Salary", employee.salary));
            employeeNode.Add(new XElement("Rating", employee._rating));
            return employeeNode;
        }

        public void UpdateEmployeeDetails(string newFirstName, string newLastName, string newEGN, int ID, string newHometown = "Unknown")
        {
            this.UpdatePersonalDetails(newFirstName, newLastName, newEGN, newHometown);
            if (ID < 0)
            {
                throw new ArgumentException("Identification number cannot be negative");
            }
            this.id = ID;
        }
        //asd
    }
}
