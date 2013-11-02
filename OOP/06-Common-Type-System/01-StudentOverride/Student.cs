namespace StudentOverride
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    public class Student : Person, ICloneable, IComparable<Student>
    {
        // Fields
        private string _adress;
        private string _email;
        private string _gSM;
        private Universities? _university;
        private Faculties? _faculty;
        private Specialties? _speciality;

        public string Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                string regex = @"[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,4}";
                if (Regex.IsMatch(value, regex))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Invalid email!");
                }

            }
        }

        public string GSM
        {
            get { return _gSM; }
            set { _gSM = value; }
        }

        public Universities? University
        {
            get { return _university; }
            set { _university = value; }
        }

        public Faculties? Faculty
        {
            get { return _faculty; }
            set { _faculty = value; }
        }

        public Specialties? Speciality
        {
            get { return _speciality; }
            set { _speciality = value; }
        }

        // Constructors
        public Student(
                string firstName, string middleName, string lastName,
                string socialSecurityNumber, string adress, string email, string gsm,
                Universities? university = null, Faculties? faculty = null, Specialties? speciality = null)
            : base(firstName, middleName, lastName, socialSecurityNumber, age: null)
        {
            this.Adress = adress;
            this.Email = email;
            this.GSM = gsm;
            this.University = university;
            this.Faculty = faculty;
            this.Speciality = speciality;
        }

        // Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return firstStudent.SocialSecurityNumber == secondStudent.SocialSecurityNumber;
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return firstStudent.SocialSecurityNumber != secondStudent.SocialSecurityNumber;
        }

        public override bool Equals(object otherStudent)
        {
            Student student = otherStudent as Student;
            if (this.SocialSecurityNumber == student.SocialSecurityNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return SocialSecurityNumber.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("StudentInfo: ");
            builder.AppendLine(new String('-', 30));
            builder.AppendLine(base.ToString());
            builder.AppendFormat("Address: {0} \n", this.Adress);
            builder.AppendFormat("GSM: {0} \n", this.GSM);
            builder.AppendFormat("Email: {0} \n", this.Email);
            builder.AppendFormat("University: {0} \n", this.University);
            builder.AppendFormat("Faculty: {0} \n", this.Faculty);
            builder.AppendFormat("Specialty: {0} \n", this.Speciality);
            return builder.ToString();
        }

        // 02. Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student.
        public object Clone()
        {
            return new Student(
                this.FirstName, this.MiddleName, this.LastName,
                this.SocialSecurityNumber, this.Adress, this.Email, this.GSM,
                this.University, this.Faculty, this.Speciality
                );
        }

        public int CompareTo(Student otherStudent)
        {
            if (this.FirstName.CompareTo(otherStudent.FirstName) != 0)
            {
                return this.FirstName.CompareTo(otherStudent.FirstName);
            }
            else if (this.MiddleName.CompareTo(otherStudent.MiddleName) != 0)
            {
                return this.MiddleName.CompareTo(otherStudent.MiddleName);
            }
            else if (this.SocialSecurityNumber.CompareTo(otherStudent.SocialSecurityNumber) != 0)
            {
                return this.SocialSecurityNumber.CompareTo(otherStudent.SocialSecurityNumber);
            }
            else
            {
                return 0;
            }
        }

    }
}
