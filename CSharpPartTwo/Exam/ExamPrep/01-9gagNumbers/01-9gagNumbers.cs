using System;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    static void Main()
    {
                              // 0    1      2     3     4     5       6     7        8 
        //string[] gagDigits = { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
        string gagNumber = Console.ReadLine();
        List<byte> convertedGag = new List<byte>(); 

        for (int i = 0; i < gagNumber.Length; i++)
        {
            switch (gagNumber[i])
            {
                case '*':
                    if (gagNumber[i + 1] == '*')
                    {
                        // gagDigits[1]
                        convertedGag.Add(1);
                        i += 1;
                    }
                    else
                    {
                        // gagDigits[6]
                        convertedGag.Add(6);
                        i += 3;
                    }
                    break;
                case '-':
                    convertedGag.Add(0);
                    i += 1;
                    break;
                case '!':
                    if (gagNumber[i + 1] == '!')
                    {
                        if (gagNumber[i + 2] == '!')
                        {
                            convertedGag.Add(2);
                            i += 2;
                        }
                        else
                        {
                            convertedGag.Add(8);
                            i += 5;
                        }
                    }
                    else
                    {
                        convertedGag.Add(5);
                        i += 1;
                    }
                    break;
                case '&':
                    if (gagNumber[i + 1] == '*')
                    {
                        convertedGag.Add(7);
                        i += 2;
                    }
                    else
                    {
                        if (gagNumber[i + 1] == '&')
                        {
                            convertedGag.Add(3);
                            i += 1;
                        }
                        else if (gagNumber[i + 1] == '-')
                        {
                            convertedGag.Add(4);
                            i += 1;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        BigInteger decimalNumber = 0;
        for (int i = 0, j = convertedGag.Count - 1; i < convertedGag.Count; i++, j--)
        {
            decimalNumber += convertedGag[i] * BigInteger.Pow(9, j);
        }
        Console.WriteLine(decimalNumber);
    }
}