using System;

public abstract class Human
{
    // Fields
    private string firstName;
    private string lastName;

    // Properties
    public string Firstname
    {
        get { return firstName; }
        set
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("The first name is too short!");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("The second name is too short!");
            }
            this.lastName = value;
        }
    }

    // Constructors
    public Human(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }
}
