using System;
using System.Text;

class SubstringSBTest
{
    static void Main()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("The special love I have for you! My baby blue");
        Console.WriteLine(builder.SubString(12, 4));
        Console.WriteLine(builder.SubString(33));
    }
}
