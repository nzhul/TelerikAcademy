// 03.
// Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. 
// Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface).
// Kittens and tomcats are cats. All animals are described by age, name and sex. Kittens can be only 
// female and tomcats can be only male. Each animal produces a specific sound. Create arrays of different
// kinds of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).


using System;
using System.Collections.Generic;

namespace Animals
{
    class TEST
    {
        static void Main()
        {
            Dog dogNinja = new Dog("Stamat", 6, Sex.Male);
            dogNinja.Sound();

            Kitten kotence = new Kitten("Eli", 1, Sex.Female);

            // This will throw exeption
            // Kitten kotence = new Kitten("Eli", 1, Sex.Male);

            List<Animal> animalList = new List<Animal>();
            animalList.Add(new Frog("Stamat", 2, Sex.Male));
            animalList.Add(new Tomcat("Stamat", 1, Sex.Male));
            animalList.Add(new Dog("Stamat", 3, Sex.Male));
            animalList.Add(new Kitten("Stamat", 5, Sex.Female));
            animalList.Add(new Frog("Stamat", 7, Sex.Male));
            animalList.Add(new Tomcat("Stamat", 12, Sex.Male));
            animalList.Add(new Dog("Stamat", 65, Sex.Male));
            animalList.Add(new Kitten("Stamat", 47, Sex.Female));
            animalList.Add(new Frog("Stamat", 12, Sex.Male));
            animalList.Add(new Tomcat("Stamat", 36, Sex.Male));
            animalList.Add(new Dog("Stamat", 48, Sex.Male));
            animalList.Add(new Kitten("Stamat", 16, Sex.Female));
            animalList.Add(new Frog("Stamat", 42, Sex.Male));
            animalList.Add(new Tomcat("Stamat", 36, Sex.Male));
            animalList.Add(new Dog("Stamat", 71, Sex.Male));
            animalList.Add(new Kitten("Stamat", 30, Sex.Female));

            int averageAge = Animal.AverageAge(animalList);
            Console.WriteLine("The average age of all animals is: {0}", averageAge);
            
        }
    }
}
