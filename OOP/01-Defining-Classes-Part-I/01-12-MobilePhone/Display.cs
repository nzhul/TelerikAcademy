using System;
using System.Text;

class Display
{
    private int size;
    private int? numberOfColors;

    //Constructors
    public Display(int size)
        : this(size, null)
    { }

    public Display(int size, int? numberOfColors)
    {
        this.size = size;
        this.numberOfColors = numberOfColors;
    }

    // Properties
    public int Size 
    {
        get 
        {
            return this.size;
        }
        set 
        {
            if (value >= 0)
            {
                this.size = value;
            }
            else
            {
                throw new ArgumentException("Invalid Display Size!");
            }
        }
    }

    public int? NumberOfColors
    {
        get
        {
            return this.numberOfColors;        
        }
        set
        {
            if (value >= 0 || value == null)
            {
                this.numberOfColors = value;
            }
            else
            {
                throw new ArgumentException("Invalid number of colors!");
            }
        }
    }

    // ToString OverRide
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("----------Display----------");
        builder.AppendLine(string.Format("Size: {0} in", this.size.ToString()));
        builder.AppendLine(string.Format("Colors: {0}", this.numberOfColors.ToString()));
        return builder.ToString();
    }

}
