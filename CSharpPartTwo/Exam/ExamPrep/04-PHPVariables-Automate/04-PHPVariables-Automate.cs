// 100/100 in bgcoder

using System;
using System.Collections.Generic;
using System.Text;

enum ParserState
{
    Normal,
    SingleQuote,
    DoubleQuote,
    MultiLineComment,
    SingleLineComment
}

class PHPVariables
{
    static List<string> variables = new List<string>();
    static ParserState state = ParserState.Normal;
    static bool addChars = false;
    static StringBuilder varBuilder = new StringBuilder();

    static void Main()
    {
        string input = "";
        while (input != "?>")
        {
            input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '$')
                {
                    if (addChars)
                    {
                        AddVariable();
                    }
                    switch (state)
                    {
                        case ParserState.Normal:
                            addChars = true;
                            break;
                        case ParserState.SingleQuote:
                            if (i > 0 && input[i - 1] != '\\' || 
                               (i > 1 && input[i - 1] == '\\' && input[i - 2] == '\\'))
                            {
                                addChars = true;
                            }
                            break;
                        case ParserState.DoubleQuote:
                            if (i > 0 && input[i - 1] != '\\' ||
                               (i > 1 && input[i - 1] == '\\' && input[i - 2] == '\\'))
                            {
                                addChars = true;
                            }
                            break;
                        case ParserState.MultiLineComment:
                            break;
                        case ParserState.SingleLineComment:
                            break;
                        default:
                            break;
                    }
                }
                else if (input[i] == '"' )
                {
                    if (addChars)
                    {
                        AddVariable();
                    }
                    switch (state)
                    {
                        case ParserState.Normal:
                            // If we are in Normal State and we encounter double Quote
                            // we set the state to DoubleQuote
                            state = ParserState.DoubleQuote;
                            break;
                        case ParserState.SingleQuote:
                            break;
                        case ParserState.DoubleQuote:
                            // if we are allready in doubleQuote State and we encounter another double quote
                            // that is not escaped - we set the state to normal
                            if (i > 0 && input[i - 1] != '\\' || 
                               (i > 1 && input[i - 1] == '\\' && input[i - 2] == '\\'))
                            {
                                state = ParserState.Normal;
                            }
                            break;
                        case ParserState.MultiLineComment:
                            break;
                        case ParserState.SingleLineComment:
                            break;
                        default:
                            break;
                    }
                }
                else if (input[i] == '\'')
                {
                    if (addChars)
                    {
                        AddVariable();
                    }

                    switch (state)
                    {
                        case ParserState.Normal:
                            // If we are in Normal State and we encounter single quote
                            // we set the state to SingleQuote;
                            state = ParserState.SingleQuote;
                            break;
                        case ParserState.SingleQuote:
                            // if we are allready in singleQuote State and we encounter another single quote
                            // that is not escaped - we set the state to normal
                            if (i > 0 && input[i - 1] != '\\' || 
                               (i > 1 && input[i - 1] == '\\' && input[i - 2] == '\\'))
                            {
                                state = ParserState.Normal;
                            }
                            break;
                        case ParserState.DoubleQuote:
                            break;
                        case ParserState.MultiLineComment:
                            break;
                        case ParserState.SingleLineComment:
                            break;
                        default:
                            break;
                    }
                    
                }
                else if (input[i] == '/')
                {
                    if (addChars)
                    {
                        AddVariable();
                    }
                    switch (state)
                    {
                        case ParserState.Normal:
                            // Check if this is start for singleLine Comment
                            if (i < input.Length - 1 && input[i + 1] == '/')
                            {
                                state = ParserState.SingleLineComment;
                            }
                            // Check if this is start for MultiLine Comment
                            if (i < input.Length - 1 && input[i + 1] == '*')
                            {
                                state = ParserState.MultiLineComment;
                            }
                            break;
                        case ParserState.SingleQuote:
                            break;
                        case ParserState.DoubleQuote:
                            break;
                        case ParserState.MultiLineComment:
                            // check if this is closing tag for multilineComment
                            if (i > 0 && input[i - 1] == '*')
                            {
                                state = ParserState.Normal;
                            }
                            break;
                        case ParserState.SingleLineComment:
                            break;
                        default:
                            break;
                    }
                }
                else if (input[i] == '#')
                {
                    if (addChars)
                    {
                        AddVariable();
                    }
                    switch (state)
                    {
                        case ParserState.Normal:
                            // if we are in normal state and we encounter # sign
                            // we set the state to SingleLineComment
                            state = ParserState.SingleLineComment;
                            break;
                        case ParserState.SingleQuote:
                            break;
                        case ParserState.DoubleQuote:
                            break;
                        case ParserState.MultiLineComment:
                            break;
                        case ParserState.SingleLineComment:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (addChars)
                    {
                        if (char.IsDigit(input[i]) || char.IsLetter(input[i]) || input[i] == '_')
                        {
                            varBuilder.Append(input[i]);
                        }
                        else
                        {
                            AddVariable();
                        }
                    }
                }
            }
            if (state == ParserState.SingleLineComment)
            {
                state = ParserState.Normal;
            }
            if (addChars)
            {
                AddVariable();
            }
        }

        Console.WriteLine(variables.Count);
        variables.Sort(StringComparer.Ordinal);
        foreach (string variable in variables)
        {
            Console.WriteLine(variable);
        }
    }

    private static void AddVariable()
    {
        string currentVar = varBuilder.ToString();

        if (currentVar != "")
        {
            if (!variables.Contains(currentVar))
            {
                variables.Add(currentVar);
            }
        }
        varBuilder.Clear();
        addChars = false;
    }
}
