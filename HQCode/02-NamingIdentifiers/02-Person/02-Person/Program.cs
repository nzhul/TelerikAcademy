using System;

class Program
{
    enum Sex { Male, Female };

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }

        public override string ToString()
        {
            return String.Format("Name: {0}; Age: {1}; Sex: {2}", this.Name, this.Age, this.Sex);
        }
    }

    static Person MakePerson(int age)
    {
        Person person = new Person();

        person.Age = age;

        if (age % 2 == 0)
        {
            person.Name = "Батката";
            person.Sex = Sex.Male;
        }
        else
        {
            person.Name = "Мацето";
            person.Sex = Sex.Female;
        }

        return person;
    }

    static void Main()
    {
        Console.WriteLine(MakePerson(19));
    }
}