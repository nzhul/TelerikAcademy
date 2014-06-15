using System;
using System.Text;

public class Student
{
    private string firstName;
    private int age;
    private string lastName;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Student(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(string.Format("{0}-{1}", this.firstName, this.lastName));
        return builder.ToString();
    }

}
