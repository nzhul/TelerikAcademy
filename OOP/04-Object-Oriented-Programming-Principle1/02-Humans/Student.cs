using System;

public class Student : Human
{
    // Fields
    private double grade;

    // Properties
    public double Grade
    {
        get { return this.grade; }
        set
        {
            if (value < 2)
            {
                throw new ArgumentException("The minimum value of the grade is 2");
            }
            else if (value > 6)
            {
                throw new ArgumentException("The maximum value of the grade is 6");
            }
            this.grade = value;
        }
    }

    // Constructor
    public Student(string firstName, string lastName, double grade)
        : base(firstName, lastName)
    {
        this.Grade = grade;
    }

    // ToString override
    public override string ToString()
    {
       return String.Format("{0} {1} - {2}", this.Firstname, this.LastName, this.Grade);
    }
}
