using System;
using System.Collections.Generic;


public class School
{
    // Fields
    public readonly List<SchoolClass> Classes;

    public School()
    {
        this.Classes = new List<SchoolClass>();
    }

    public void AddClass(SchoolClass newClass)
    {
        this.Classes.Add(newClass);
    }
}
