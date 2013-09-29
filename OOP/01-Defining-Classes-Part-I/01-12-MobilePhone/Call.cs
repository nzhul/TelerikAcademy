using System;
using System.Text;

class Call
{
    private DateTime startDateTime;
    private DateTime endDateTime;
    private string dialedNumber;

    // Constructors
    public Call(DateTime startDateTime, DateTime endDateTime, string dialedNumber)
    {
        this.startDateTime = startDateTime;
        this.endDateTime = endDateTime;
        this.dialedNumber = dialedNumber;
    }

    // Properties
    public string Date
    {
        get
        {
            return this.startDateTime.ToShortDateString();
        }
    }

    public string Time
    {
        get
        {
            return this.startDateTime.ToShortTimeString();
        }
    }

    public string DialedNumber
    {
        get
        {
            return this.dialedNumber;
        }
    }

    public double Duration
    {
        get
        {
            double durationInSeconds = (this.endDateTime - this.startDateTime).TotalSeconds;
            return durationInSeconds;
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("Call Info: ");
        builder.Append(string.Format("Number: {0} ", this.DialedNumber));
        builder.Append(string.Format("Date: {0} ", this.Date));
        builder.Append(string.Format("Time: {0} ", this.Time));
        builder.Append(string.Format("Duration: {0} seconds", this.Duration));
        return builder.ToString();
    }
}
