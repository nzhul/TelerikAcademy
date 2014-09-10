namespace ColoredRabbits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            int allRabbits = int.Parse(Console.ReadLine());

            Dictionary<double, double> rabbits = new Dictionary<double, double>();
            for (int i = 0; i < allRabbits; i++)
            {
                double currentRabbit = double.Parse(Console.ReadLine()) + 1;

                if (rabbits.ContainsKey(currentRabbit))
                {
                    rabbits[currentRabbit]++;
                }
                else
                {
                    rabbits.Add(currentRabbit, 1);
                }
            }

            double result = 0;

            foreach (var rabbit in rabbits)
            {
                if (rabbit.Value == 1)
                {
                    result += rabbit.Key;
                }
                else
                {
                    result += Math.Ceiling(rabbit.Value / rabbit.Key) * rabbit.Key;
                }
            }

            Console.WriteLine(result);
        }
    }
}
