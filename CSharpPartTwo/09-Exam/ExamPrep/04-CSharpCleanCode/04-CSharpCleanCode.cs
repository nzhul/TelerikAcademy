// 70/100 in bgcoder

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

enum ParserStates
{
    Normal,
    SingleLineComment,
    MultiLineComment,
    Quote,
    FullEscape
}

class CleanCode
{
    static StringBuilder cleanBuilder = new StringBuilder();
    static void Main()
    {
        ParserStates state = ParserStates.Normal;
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            if (state == ParserStates.SingleLineComment)
            {
                state = ParserStates.Normal;
            }
            string line = Console.ReadLine();
            for (int j = 0; j < line.Length; j++)
            {
                char currChar = line[j];
                if (currChar == '/')
                {
                    switch (state)
                    {
                        case ParserStates.Normal:
                            // Check if this is a start for singleLine Comment
                            if (j < line.Length - 1 && line[j + 1] == '/')
                            {
                                state = ParserStates.SingleLineComment;
                            }
                            else if (j < line.Length - 1 && line[j + 1] == '*')
                            {
                                state = ParserStates.MultiLineComment;
                            }
                            break;
                        case ParserStates.SingleLineComment:
                            break;
                        case ParserStates.MultiLineComment:
                            if (j > 0 && line[j - 1] == '*')
                            {
                                state = ParserStates.Normal;
                                continue;
                            }
                            break;
                        case ParserStates.Quote:
                            break;
                        case ParserStates.FullEscape:
                            break;
                        default:
                            break;
                    }
                }
                else if (currChar == '"')
                {
                    switch (state)
                    {
                        case ParserStates.Normal:
                            if ((j > 1 && line[j - 1] != '\\') || (j > 1 && line[j - 2] != '\''))
                            {
                                state = ParserStates.Quote;
                            }
                            break;
                        case ParserStates.SingleLineComment:
                            break;
                        case ParserStates.MultiLineComment:
                            break;
                        case ParserStates.Quote:
                            // if we are allready in doubleQuote State and we encounter another double quote
                            // that is not escaped - we set the state to normal
                            if (j > 0 && line[j - 1] != '\\' ||
                               (j > 1 && line[j - 1] == '\\' && line[j - 2] == '\\'))
                            {
                                state = ParserStates.Normal;
                            }
                            break;
                        case ParserStates.FullEscape:
                            // This is the end of the full escape - @
                            if (j < line.Length - 1 && line[j + 1] == ';')
                            {
                                state = ParserStates.Normal;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (currChar == '@')
                {
                    switch (state)
                    {
                        case ParserStates.Normal:
                            // If the next character is doubleQuote - we enter FullEscape State
                            if (j < line.Length && line[j + 1] == '"')
                            {
                                state = ParserStates.FullEscape;
                            }
                            break;
                        case ParserStates.SingleLineComment:
                            break;
                        case ParserStates.MultiLineComment:
                            break;
                        case ParserStates.Quote:
                            break;
                        case ParserStates.FullEscape:
                            break;
                        default:
                            break;
                    }
                }

                if (state != ParserStates.SingleLineComment && state != ParserStates.MultiLineComment)
                {
                    // Add Character
                    cleanBuilder.Append(currChar);
                }
            }
            if (i != n - 1 && state != ParserStates.MultiLineComment)
            {
                cleanBuilder.Append("\r\n");
            }
        }

        string[] finalOutput = cleanBuilder.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        cleanBuilder.Clear();
        for (int i = 0; i < finalOutput.Length; i++)
        {
            Match match = Regex.Match(finalOutput[i], @"^\s+$");
            if (match.Success)
            {
                continue;
            }
            else
            {
                cleanBuilder.Append(finalOutput[i]);
                if (i != finalOutput.Length - 1)
                {
                    cleanBuilder.AppendLine();
                }
            }
        }

        //File.WriteAllText("../../output.txt",cleanBuilder.ToString());
        Console.WriteLine(cleanBuilder);
    }
}