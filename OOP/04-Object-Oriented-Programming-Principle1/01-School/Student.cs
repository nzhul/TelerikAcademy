using System;
using System.Collections.Generic;


public class Student : Human, ICommentable
{
    // Fields
    private string uniqueClassNumber;

    // Properties
    public string UniqueClassNumber
    {
        get { return this.uniqueClassNumber; }
        set
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("Invalid Student Number");
            }
            this.uniqueClassNumber = value;
        }
    }

    // Constructor
    public Student(string name, string uniqueClassNumber)
        : base(name)
    {
        this.uniqueClassNumber = uniqueClassNumber;
    }

}
