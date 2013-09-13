using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        private const string RevTagOpen = "<rev>";
        private const string UpperTagOpen = "<upper>";
        private const string LowerTagOpen = "<lower>";
        private const string ToggleTagOpen = "<toggle>";
        private const string DelTagOpen = "<del>";

        private const string RevTagClose = "</rev>";
        private const string UpperTagClose = "</upper>";
        private const string LowerTagClose = "</lower>";
        private const string ToggleTagClose = "</toggle>";
        private const string DelTagClose = "</del>";

        private static StringBuilder output = new StringBuilder();
        private static int openedDelTags = 0;
        private static List<string> currentOpenedTag = new List<string>();

        private static List<int> revTagStarts = new List<int>();

        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string currLine = Console.ReadLine();
                int currSymbolIndex = 0;
                while (currSymbolIndex < currLine.Length)
                {
                    if (currLine[currSymbolIndex] == '<')
                    {
                        string tag = GetTag(currLine, currSymbolIndex);
                        ProcessTag(tag);
                        currSymbolIndex += tag.Length - 1;
                    }
                    else
                    {
                        if (openedDelTags == 0)
                        {
                            char symbolToAdd = currLine[currSymbolIndex];
                            for (int j = currentOpenedTag.Count - 1; j >= 0; j--)
                            {
                                symbolToAdd = ApplyEffect(symbolToAdd, currentOpenedTag[j]);
                            }
                            output.Append(symbolToAdd);
                        }
                    }
                    currSymbolIndex++;
                }
                output.Append('\n');
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static void ProcessTag(string tag)
        {
            if (tag == DelTagOpen)
            {
                openedDelTags++;
            }
            else if (tag == DelTagClose)
            {
                openedDelTags--;
            }
            else
            {
                if (openedDelTags == 0)
                {
                    if (tag == RevTagOpen)
                    {
                        revTagStarts.Add(output.Length);
                    }
                    else if (tag == RevTagClose)
                    {
                        int currentRevStart = revTagStarts[revTagStarts.Count - 1];
                        int revEnd = output.Length - 1;
                        Reverse(currentRevStart, revEnd);
                        revTagStarts.RemoveAt(revTagStarts.Count - 1);
                    }
                    else if (tag[1] == '/')
                    {
                        currentOpenedTag.RemoveAt(currentOpenedTag.Count - 1);
                    }
                    else
                    {
                        currentOpenedTag.Add(tag);
                    }
                }
            }
        }

        private static void Reverse(int currentRevStart, int revEnd)
        {
            int start = currentRevStart;
            int end = revEnd;
            while (start < end)
            {
                char bufferChar = output[start];
                output[start] = output[end];
                output[end] = bufferChar;
                end--;
                start++;
            }
        }

        private static string GetTag(string currLine, int currSymbolIndex)
        {
            int tagsStart = currSymbolIndex;
            int tagEnd = currLine.IndexOf('>', tagsStart + 1);
            string tag = currLine.Substring(tagsStart,tagEnd - tagsStart + 1);

            return tag;
        }


        private static char ApplyEffect(char symbolToAdd, string currentOpenTag)
        {
            if (char.IsLetter(symbolToAdd))
            {
                if (currentOpenTag == UpperTagOpen)
                {
                    symbolToAdd = char.ToUpper(symbolToAdd);
                }
                else if (currentOpenTag == LowerTagOpen)
                {
                    symbolToAdd = char.ToLower(symbolToAdd);
                }
                else if (currentOpenTag == ToggleTagOpen)
                {
                    if (char.IsLower(symbolToAdd))
                    {
                        symbolToAdd = char.ToUpper(symbolToAdd);
                    }
                    else if (char.IsUpper(symbolToAdd))
                    {
                        symbolToAdd = char.ToLower(symbolToAdd);
                    }
                }
            }
            return symbolToAdd;
        }
    }
