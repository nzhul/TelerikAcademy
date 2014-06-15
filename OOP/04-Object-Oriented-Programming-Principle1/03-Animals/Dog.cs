using System;

namespace Animals
{
    public class Dog : Animal, ISound
    {
        // Constructor
        public Dog(string name, int age, Sex sex)
            : base(name, age, sex)
        { }

        // ISound Implementation
        public void Sound()
        {
            Console.WriteLine("Woof-Woof!");
        }
    }
}
