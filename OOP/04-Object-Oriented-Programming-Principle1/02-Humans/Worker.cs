using System;

public class Worker : Human
{
    // Fields
    private int weekSalary;
    private int workHoursPerDay;


    // Properties
    public int WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("The Salary cannot be 0 or neagative number!");
            }
            this.weekSalary = value;
        }
    }

    public int WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("The working hours cannot be 0 or less!");
            }
            else if (value > 24)
            {
                throw new ArgumentException("There are 24 hours in one day! :)");
            }
            this.workHoursPerDay = value;
        }
    }

    // Constructors
    public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    // Methods
    public int MoneyPerHour()
    {
        int moneyPerHourCount = 0;
        moneyPerHourCount = this.WeekSalary / this.WorkHoursPerDay * 5;
        return moneyPerHourCount;
    }

    // ToString override
    public override string ToString()
    {
        return String.Format("{0} {1} - {2}", this.Firstname, this.LastName, MoneyPerHour());
    }

}
