using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName = null;
    public string FirstName
    {
        get { return this.firstName; }
        private set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid first name!");

            this.firstName = value;
        }
    }

    private string lastName = null;
    public string LastName
    {
        get { return this.lastName; }
        private set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid last name!");

            this.lastName = value;
        }
    }

    private IList<Exam> exams = null;
    public IList<Exam> Exams
    {
        get { return this.exams; }
        private set
        {
            this.exams = value ?? new List<Exam>();
        }
    }

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public IList<ExamResult> CheckExams()
    {
        return this.Exams.Select(exam =>
            exam.Check()
        ).ToList();
    }

    public decimal CalcAverageExamResultInPercents()
    {
        return this.CheckExams().Average(res =>
            res.CalcInPercents()
        );
    }
}