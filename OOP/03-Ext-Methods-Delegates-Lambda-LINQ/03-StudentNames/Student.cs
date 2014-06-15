using System;
using System.Text;

public class Student
{
    private string firstName;
    private string lastName;

    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public Student(string firstName, string secondName)
    {
        this.firstName = firstName;
        this.lastName = secondName;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(string.Format("{0}-{1}", this.firstName, this.lastName));
        return builder.ToString();
    }
    
}
