using System;

public delegate void Ticker(int start);

public class Timer
{
    private int numbers;

    public int Numbers
    {
        get { return numbers; }
        set { numbers = value; }
    }

    public void TickerProcess(int start)
    {
        Console.WriteLine(this.numbers);
        this.numbers++;
    }
    
}