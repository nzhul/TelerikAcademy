using System;
using System.Text;

public class Student
{
    private string firstName;
    private string secondName;

    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }

    public string SecondName
    {
        get { return secondName; }
        set { secondName = value; }
    }

    public Student(string firstName, string secondName)
    {
        this.firstName = firstName;
        this.secondName = secondName;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(string.Format("{0}-{1}", this.firstName, this.secondName));
        return builder.ToString();
    }
    
}
