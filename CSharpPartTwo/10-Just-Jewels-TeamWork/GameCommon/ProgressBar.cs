using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameCommon
{
    public class ProgressBar
    {
        private const char SYMBOL = '\u2591'; // '\u2590';
        private Timer timer;
        private static int counter = 1;

        public ProgressBar()
        {
            Console.CursorVisible = false;
            Start();
            Thread.Sleep(60000); //TEST for 60 sec
            Stop();
        }
        private void Start()
        {
            TimerCallback callBack = new TimerCallback(OnTick);
            timer = new Timer(callBack, null, 0, 570);
        }
        private void Stop()
        {
            timer.Dispose();
            timer = null;
        }
        private void OnTick(object state)
        {
            DrawProgress(counter);
            counter++;
        }

        public static void DrawProgress(int percentage)
        {
            DrawProgress(percentage, SYMBOL, ConsoleColor.Red);
        }

        public static void DrawProgress(int percentage, char progressBarCharacter, ConsoleColor color)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            int width = Console.WindowWidth - 1;
            int newWidth = (int)((width * percentage) / 100);
            string progress = new string(progressBarCharacter, newWidth);
            Console.SetCursorPosition(0, 37);
            Console.Write(progress);
            Console.ForegroundColor = currentColor;
        }
    }
}
