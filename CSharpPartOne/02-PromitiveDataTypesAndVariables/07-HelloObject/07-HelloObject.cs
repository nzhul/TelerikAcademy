// 7. Declare two string variables and assign them with “Hello” and “World”. Declare an object variable and assign 
// it with the concatenation of the first two variables (mind adding an interval). Declare a third string variable and initialize 
// it with the value of the object variable (you should perform type casting).



using System;


class HelloObject
{
    static void Main()
    {
        string word1 = "Hello";
        string word2 = "World";

        object greeting = word1 + " " + word2;
        string castedGreeting = (string)greeting;

        Console.WriteLine("Print all variables:\n string word1 == {0}\n string word2 == {1}\n object greeting == {2}\n string castedGreeting == {3}", word1, word2, greeting, castedGreeting);
    }
}

