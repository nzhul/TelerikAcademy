namespace AwesomeComputers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ColorfulVideoCard : IVideoCard
    {
        public void Draw(string textToDraw)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(textToDraw);
            Console.ResetColor();
        }
    }
}
