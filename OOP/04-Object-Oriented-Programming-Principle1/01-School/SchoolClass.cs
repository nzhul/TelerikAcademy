using System;
using System.Collections.Generic;

public class SchoolClass : ICommentable
{
    // Fields
    public readonly List<Teacher> ClassTeachersList;
    public readonly List<Student> ClassStudentsList;
    private List<string> comments;

    public List<string> Comments
    {
        get { return comments; }
        set { comments = value; }
    }
    

    private string classID;

    // Properties
    public string ClassID
    {
        get { return this.classID; }
        set
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("Invalid Class ID!");
            }
            this.classID = value;
        }
    }

    // Constructors
    public SchoolClass()
    {
        this.ClassTeachersList = new List<Teacher>();
        this.ClassStudentsList = new List<Student>();
    }

    // Methods
    public void AddTeacher(Teacher teacher)
    {
        this.ClassTeachersList.Add(teacher);
    }
    public void AddStudent(Student student)
    {
        this.ClassStudentsList.Add(student);
    }

    // ICommentable Implementation
    public void AddComment(string comment)
    {
        this.Comments.Add(comment);
    }


}