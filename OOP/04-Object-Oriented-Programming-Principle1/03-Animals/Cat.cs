using System;

namespace Animals
{
    class Cat : Animal, ISound
    {
        // Constructor
        public Cat(string name, int age)
            : base(name, age)
        { }

        public Cat(string name, int age, Sex sex)
            : base(name, age, sex)
        { }

        public void Sound()
        {
            Console.WriteLine("Meow, meow!");
        }
    }
}
