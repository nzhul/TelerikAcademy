using System;
using System.Collections.Generic;

public class Teacher : Human, ICommentable
{
    public readonly List<Discipline> TeacherDisciplinesList;

    // Constructor
    public Teacher(string name)
        : base(name)
    {
        this.TeacherDisciplinesList = new List<Discipline>();
    }

    public void AddDiscipline(Discipline discipline)
    {
        this.TeacherDisciplinesList.Add(discipline);
    }
}
