using System;



class AstrologicalDigits
{
    static void Main()
    {
        string n = Console.ReadLine().Trim(new Char[] { '-', '.' });
        int dotIndex = n.IndexOf('.');
        if (dotIndex > 0)
        {
            n = n.Remove(dotIndex, 1);
        }

        int sum = 0;
        while (true)
        {
            for (int i = 0; i < n.Length; i++)
            {
                sum += (int)Char.GetNumericValue(n[i]);
            }
            if (sum > 9)
            {
                n = Convert.ToString(sum);
                sum = 0;
            }
            else
            {
                break;
            }
        }
        Console.WriteLine(sum);
    }
}