using System;

namespace Animals
{
    class Frog : Animal, ISound
    {
        public Frog(string name, int age, Sex sex)
            : base(name, age, sex)
        { }

        public void Sound()
        {
            Console.WriteLine("Ribbit, ribbit");
        }
    }
}
