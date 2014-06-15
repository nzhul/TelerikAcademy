using System;
using System.Text;

public enum BatteryType
{
    LiPoly,
    LiIon,
    NiCd,
    NiMH
}

public class Battery
{
    // Define Battery fields
    private BatteryType type;
    private int? hoursIdle;
    private int? hoursTalk;

    // Constructors
    public Battery(BatteryType type)
        : this(type, null, null)
    {
    }

    public Battery(BatteryType type, int? hoursIdle)
        : this(type, hoursIdle, null)
    {
    }

    public Battery(BatteryType type, int? hoursIdle, int? hoursTalk)
    {
        this.type = type;
        this.hoursIdle = hoursIdle;
        this.hoursTalk = hoursTalk;
    }

    // Properties
    public BatteryType Type
    {
        get
        {
            return this.type;
        }
        set
        {
            this.type = value;
        }
    }

    public int? HoursIdle
    {
        get { return this.hoursIdle; }
        set
        {
            if (value >= 0 || value == null)
            {
                this.hoursIdle = value;
            }
            else
            {
                throw new ArgumentException("Invalid HoursIdle!");
            }
        }
    }

    public int? HoursTalked
    {
        get { return this.hoursTalk; }
        set
        {
            if (value >= 0 || value == null)
            {
                this.hoursTalk = value;
            }
            else
            {
                throw new ArgumentException("Invalid HoursTalked!");
            }
        }
    }

    // ToString OverRide
    public override string ToString()
    {

        StringBuilder builder = new StringBuilder();
        builder.AppendLine("----------Battery----------");
        builder.AppendLine(string.Format("Battery type: {0}", this.type.ToString()));
        builder.AppendLine(string.Format("Hours Idle: {0}", this.hoursIdle));
        builder.AppendLine(string.Format("Hours Talk: {0}", this.hoursTalk));
        return builder.ToString();
    }



}