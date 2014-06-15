// 07. Using delegates write a class Timer that has can execute certain method at each t seconds.

using System;
using System.Threading;

class TimerTest
{
    public delegate void CountEventHandler();
    public event CountEventHandler Counter;
    static void Main()
    {
        Timer timerObj = new Timer();
        Ticker timer = new Ticker(timerObj.TickerProcess);

        while (true)
        {
            Thread.Sleep(500);
            timer(0);
        }
    }
}
