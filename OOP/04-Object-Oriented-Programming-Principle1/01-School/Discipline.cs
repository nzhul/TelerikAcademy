using System;
using System.Collections.Generic;

public class Discipline : ICommentable
{

    // Fields
    private string name;
    private int exercisesCount;
    private int lecturesCount;

    // Properties
    public string Name
    {
        get { return this.name; }
        set
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("Discipline name is too short!");
            }
            this.name = value;
        }
    }

    public int LecturesCount
    {
        get { return this.lecturesCount; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Lectures Count cannot be 0 or negative!");
            }
            this.lecturesCount = value;
        }
    }

    public int ExercisesCount
    {
        get { return this.exercisesCount; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Exercises Count cannot be 0 or negative!");
            }
            this.exercisesCount = value;
        }
    }

    private List<string> comments;

    public List<string> Comments
    {
        get { return comments; }
        set { comments = value; }
    }


    // Constructors
    public Discipline()
        : this(null, 0, 0)
    { }

    public Discipline(string name)
        : this(name, 0, 0)
    { }

    public Discipline(string name, int lecturesCount, int exercisesCount)
    {
        this.name = name;
        this.lecturesCount = lecturesCount;
        this.exercisesCount = exercisesCount;
        this.comments = new List<string>();
    }

    public void AddComment(string comment)
    {
        this.Comments.Add(comment);
    }

}
