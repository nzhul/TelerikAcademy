using System;
using System.Collections.Generic;

public class SimpleMathExam : Exam
{
    private int problemsSolved = 0;
    public int ProblemsSolved
    {
        get { return this.problemsSolved; }
        private set
        {
            if (!(0 <= value && value <= 2))
                throw new ArgumentOutOfRangeException("Problems solved");

            this.problemsSolved = value;
        }
    }

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    private readonly SortedDictionary<int, KeyValuePair<int, string>> marks =
        new SortedDictionary<int, KeyValuePair<int, string>>
    {
        { 0, new KeyValuePair<int, string>(2, "Bad result: nothing done.") },
        { 1, new KeyValuePair<int, string>(4, "Average result: something done.") },
        { 2, new KeyValuePair<int, string>(6, "Excelent result: everything done.") }
    };

    public override ExamResult Check()
    {
        var mark = this.marks[this.problemsSolved];

        return new ExamResult(mark.Key, 2, 6, mark.Value);
    }
}