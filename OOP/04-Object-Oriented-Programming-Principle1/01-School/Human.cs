using System;
using System.Collections.Generic;

public abstract class Human : ICommentable
{
    // Fields
    private string name;
    private List<string> comments;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("The Name is too short!");
            }
            this.name = value;
        }
    }

    // Properties
    public List<string> Comments
    {
        get { return this.comments; }
        set { this.comments = value; }
    }

    // Constructors
    public Human(string name)
    {
        this.name = name;
        this.Comments = new List<string>();
    }

    // Icommentable implementation for All Humans - Including Teacher and Student
    public void AddComment(string comment)
    {
        this.Comments.Add(comment);
    }

    // ToString Overrrider
    public override string ToString()
    {
        return this.Name;
    }
}
