// 6.Declare a boolean variable called isFemale and assign an appropriate value corresponding to your gender.


using System;


class MyGender
{
    static void Main()
    {
        bool isFemale = false;

        switch (isFemale)
        {
            case true:
                Console.WriteLine("Nice to meet you milady !");
                break;
            case false:
                Console.WriteLine("Good evening milord !");
                break;
        }
    }
}

