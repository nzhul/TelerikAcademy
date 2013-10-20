using System;
using System.Collections.Generic;

namespace Animals
{
    public enum Sex
    {
        Male,
        Female
    }

    public abstract class Animal
    {
        // Fields
        private string name;
        private Sex sex;
        private int age;

        // Properties
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException("The name is too short!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The age of the animal cannot be 0 or less!");
                }
                this.age = value;
            }
        }

        public Sex Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }

        // Constructors
        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public Animal(string name, int age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        // Methods
        public static int AverageAge(List<Animal> animalList)
        {
            int sum = 0;
            for (int i = 0; i < animalList.Count; i++)
            {
                sum += animalList[i].Age;
            }
            return sum / animalList.Count;
        }
    }
}
