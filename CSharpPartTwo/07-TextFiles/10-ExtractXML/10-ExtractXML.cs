// 10. Write a program that extracts from given XML file all the text without the tags. Example:
//     <?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3">
//     <interest> Games</instrest><interest>C#</instrest><interest> Java</instrest></interests></student>

using System;
using System.Collections.Generic;
using System.IO;

class ExtractXML
{
    static void Main()
    {
        string line = null;
        List<string> xmlValues = new List<string>();
        using (StreamReader reader = new StreamReader("../../XMLFile1.xml"))
        {
            while ((line = reader.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (i < line.Length - 1 && line[i] == '>' && line[i + 1] != '<')
                    {
                        int startingIndex = i + 1;
                        int wordLength = 0;
                        while (line[i] != '<')
                        {
                            wordLength++;
                            i++;
                        }
                        xmlValues.Add(line.Substring(startingIndex, wordLength - 1));
                    }
                }
            }
        }
        for (int i = 0; i < xmlValues.Count; i++)
        {
            Console.WriteLine("{0}: {1}", i+1, xmlValues[i]);
        }
    }
}