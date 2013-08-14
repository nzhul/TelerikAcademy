using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Security;

class RemoveByList
{
    static void Main()
    {
        try
        {
            string regex = @"\b(" + String.Join("|", File.ReadAllLines("../../words.txt")) + @")\b";
            string fileContent = File.ReadAllText("../../fileForClearing.txt");
            File.WriteAllText("../../ClearedFile.txt", Regex.Replace(fileContent, regex, String.Empty,RegexOptions.IgnoreCase));
            Console.WriteLine("Replace Complete!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File Not Found!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory Not Found!");
        }
        catch (IOException)
        {
            Console.WriteLine("Input/Output Error!");
        }
        catch (SecurityException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("File Access Error!");
        }
    }
}
