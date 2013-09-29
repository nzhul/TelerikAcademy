using System;
using System.Collections.Generic;
using System.Text;


class GSM
{
    // Defining the GSM Fields
    public Battery battery = new Battery(BatteryType.LiIon, null, null);
    public Display display = new Display(0, null);

    private string model;
    private string manufacturer;
    private double? price;
    private string owner;
    private List<Call> callHistory;

    // Define Static Field
    static private GSM iphone = new GSM("IPhone4S","Apple",1200,"Steve Jobs", new Battery(BatteryType.LiPoly), new Display(6, 700000));

    // Define the GSM Constructors
    public GSM(string model, string manufacturer)
        : this(model, manufacturer, null, null, null, null)
    { }

    public GSM(string model, string manufacturer, int? price)
        : this(model, manufacturer, price, null, null, null)
    { }

    public GSM(string model, string manufacturer, int? price, string owner)
        : this(model, manufacturer, price, owner, null, null)
    { }

    public GSM(string model, string manufacturer, int? price, string owner, Battery battery, Display display)
    {
        this.model = model;
        this.manufacturer = manufacturer;
        this.price = price;
        this.owner = owner;
        this.battery = battery;
        this.display = display;
        this.callHistory = new List<Call>();
    }

    // Properties
    public string Model
    {
        get { return this.model; }
        set
        {
            if (value.Length >= 0)
            {
                this.model = value;
            }
            else
            {
                throw new ArgumentException("Model name is too short!");
            }
        }
    }

    public string Manufacturer
    {
        get { return this.manufacturer; }
        set
        {
            if (value.Length >= 0)
            {
                this.manufacturer = value;
            }
            else
            {
                throw new ArgumentException("Manufacturer name is too short!");
            }
        }
    }

    public double? Price
    {
        get { return this.price; }
        set 
        {
            if (value == null || value >= 0)
            {
                this.price = value;
            }
            else
            {
                throw new ArgumentException("Invalid Price!");
            }
        }
    }

    public string Owner
    {
        get { return this.owner; }
        set 
        {
            if (value == null || value.Length >= 0)
            {
                this.owner = value;
            }
            else
            {
                throw new ArgumentException("The Owner name is too short!");
            }
        }
    }

    public static GSM Iphone
    {
        get { return iphone; }
    }

    public List<Call> CallHistory
    {
        get { return this.callHistory; }
        set { this.callHistory = value; }
    }

    public void AddCall(DateTime startDateTime, DateTime endDateTime, string dialedNumber)
    {
        this.callHistory.Add(new Call(startDateTime, endDateTime, dialedNumber));
    }

    public void DeleteCall(int callIndex)
    {
        if (callIndex > 0 && (callIndex <= this.callHistory.Count))
        {
            this.callHistory.RemoveAt(callIndex);
        }
        else
        {
            throw new ApplicationException("Call not found");
        }
    }
    public void DeleteLongestCall()
    {
        double longestDuration = double.MinValue;
        Call selectedElement = null;
        foreach (Call call in this.callHistory)
        {
            if (call.Duration > longestDuration)
            {
                longestDuration = call.Duration;
                selectedElement = call;
            }
        }
        if (selectedElement != null)
        {
            this.callHistory.Remove(selectedElement);
        }
    }

    public void ClearHistory()
    {
        this.callHistory.Clear();
    }

    public double TotalCallsCost(double pricePerMin)
    {
        double totalCallsDuration = 0;
        foreach (Call call in this.callHistory)
        {
            totalCallsDuration += call.Duration;
        }
        double totalCosts = (totalCallsDuration / 60) * pricePerMin;
        return totalCosts;
    }

    // ToString OverRide
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("----------GSM Information----------");
        builder.AppendLine("Model: " + this.model);
        builder.AppendLine("Manufacturer: " + this.manufacturer);
        builder.AppendLine("Price: $" + (this.price == null ? "unknown price" : this.price.ToString()));
        builder.AppendLine("Owner: " + (this.owner == null ? "unknown owner" : this.owner));
        builder.AppendLine();
        builder.AppendLine(this.battery.ToString());
        builder.AppendLine(this.display.ToString());
        builder.AppendLine();

        // TODO callHistory 

        return builder.ToString();
    }
    
}
