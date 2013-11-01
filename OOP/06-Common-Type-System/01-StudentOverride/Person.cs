namespace StudentOverride
{
    using System;
    using System.Text;

    public abstract class Person
    {
        // Properties
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _socialSecurityNumber;
        private int? _age;

        // Fields
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        
        public string SocialSecurityNumber
        {
            get { return _socialSecurityNumber; }
            set { _socialSecurityNumber = value; }
        }

        public int? Age
        {
            get { return _age; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid Age!");
                }
                else
                {
                    this._age = value;
                } 
            }
        }
        

        // Constructors
        public Person(string firstName, string middleName, string lastName, string socialSecurityNumber, int? age)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SocialSecurityNumber = socialSecurityNumber;
            this.Age = age;
        }

        // ToString override
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            builder.AppendLine();
            builder.AppendFormat("Social Security Number: {0}", this.SocialSecurityNumber);
            builder.AppendLine();
            if (this.Age != null)
            {
                builder.AppendFormat("Age: {0}", this.Age);    
            }
            return builder.ToString();
        }
        
    }
}
