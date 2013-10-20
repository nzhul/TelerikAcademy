using System;

namespace Animals
{
    class Kitten : Cat, ISound
    {
        // Constructor
        public Kitten(string name, int age, Sex sex)
            : base(name, age)
        {
            if (sex != Animals.Sex.Female)
            {
                throw new ArgumentException("Kittens can be Female only!");
            }
            this.Sex = sex;
        }
    }
}
