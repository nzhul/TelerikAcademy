using System;
using System.Collections.Generic;
using System.Text;

enum ParserState
{
    Normal,
    Print,
    For,
    Exit
}

//enum Brackets
//{
//    Normal,
//    For,
//    Print
//}

class BasicLanguage
{
    static void Main()
    {
        StringBuilder executeBuilder = new StringBuilder();
        bool exitFlag = true;
        List<int> forStack = new List<int>();
        while (exitFlag)
        {
            StringBuilder forBuilder = new StringBuilder();
            ParserState state = ParserState.Normal;
            //Brackets bracketState = Brackets.Normal;
            string line = Console.ReadLine();
            for (int i = 0; i < line.Length; i++)
            {
                char currChar = line[i];
                if (i < line.Length - 2 && currChar == 'P' && line[i + 1] == 'R')
                {
                    switch (state)
                    {
                        case ParserState.Normal:
                            state = ParserState.Print;
                            break;
                        case ParserState.Print:
                            break;
                        case ParserState.For:
                            state = ParserState.Print;
                            break;
                        default:
                            break;
                    }
                }
                else if (i < line.Length - 2 && currChar == 'F' && line[i + 1] == 'O')
                {
                    switch (state)
                    {
                        case ParserState.Normal:
                            state = ParserState.For;
                            break;
                        case ParserState.Print:
                            break;
                        case ParserState.For:
                            break;
                        default:
                            break;
                    }
                }
                else if (i < line.Length - 2 && currChar == 'E' && line[i + 1] == 'X')
                {
                    switch (state)
                    {
                        case ParserState.Normal:
                            state = ParserState.Exit;
                            break;
                        case ParserState.Print:
                            break;
                        case ParserState.For:
                            state = ParserState.Exit;
                            break;
                        default:
                            break;
                    }
                }
                else if (currChar == ';')
                {
                    switch (state)
                    {
                        case ParserState.Normal:
                            break;
                        case ParserState.Print:
                            state = ParserState.Normal;
                            break;
                        case ParserState.For:
                            state = ParserState.Normal;
                            break;
                        default:
                            break;
                    }
                }

                if (state == ParserState.For)
                {
                    if (currChar == '(')
                    {
                        i++;
                        currChar = line[i];
                        while (currChar != ')')
                        {
                            i++;
                            if (i >= line.Length)
                            {
                                line = Console.ReadLine();
                                i = 0;
                            }
                            forBuilder.Append(currChar);
                            currChar = line[i];
                        }
                        string[] forTokens = forBuilder.ToString().Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                        forBuilder.Clear();
                        if (forTokens.Length == 1)
                        {
                            forStack.Add(int.Parse(forTokens[0]));
                        }
                        else if (forTokens.Length == 2)
                        {
                            int a = int.Parse(forTokens[0]);
                            int b = int.Parse(forTokens[1]);
                            forStack.Add(b - a + 1);
                        }
                    }
                }

                else if (state == ParserState.Print)
                {
                    // calculate fors
                    // clear for List
                    if (currChar == '(')
                    {
                        i++;
                        if (i >= line.Length)
                        {
                            line = Console.ReadLine();
                            i = 0; 
                        }
                        currChar = line[i];
                        while (currChar != ')')
                        {
                            i++;
                            if (i >= line.Length)
                            {
                                line = Console.ReadLine();
                                i = 0;
                            }
                            forBuilder.Append(currChar);
                            currChar = line[i];
                        }
                        int forLoopsCount = 1;
                        for (int z = 0; z < forStack.Count; z++)
                        {
                            forLoopsCount *= forStack[z];
                        }
                        for (int j = 0; j < forLoopsCount; j++)
                        {
                            executeBuilder.Append(forBuilder);
                        }
                        state = ParserState.Normal;
                        forStack.Clear();
                        forBuilder.Clear();
                    }
                }

                if (state == ParserState.Exit)
                {
                    exitFlag = false;
                    break;
                }
            }

            // Reset all the stuff
            // 
        }
        Console.WriteLine(executeBuilder);
    }
}
