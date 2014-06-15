using System;

namespace Animals
{
    class Tomcat : Cat, ISound
    {
        // Constructors
        public Tomcat(string name, int age, Sex sex)
            : base(name, age)
        {
            if (sex != Animals.Sex.Male)
            {
                throw new ArgumentException("Tomcats can be Male only!");
            }
            this.Sex = sex;
        }
    }
}
