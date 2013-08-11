using System;
using System.IO;
using System.Security;

class ReadFile
{
    static void Main()
    {
        Console.Write("Please enter the full path to the file: ");
        string filePath = Console.ReadLine();
        PrintFileToConsole(filePath);
    }

    static void PrintFileToConsole(string filePath)
    {
        try
        {
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine("Printing the content of the file: ");
            Console.WriteLine(fileContent);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found!");
        }
        catch(FileNotFoundException)
        {
            Console.WriteLine("File not found!");
        }
        catch(ArgumentNullException)
        {
            Console.WriteLine("Please enter valid file path!");
        }
        catch(ArgumentException)
        {
            Console.WriteLine("Please enter valid file path!");            
        }
        catch(PathTooLongException)
        {
            Console.WriteLine("The file Path must not be longer than 248 characters!");
        }
        catch(UnauthorizedAccessException accessError)
        {
            Console.WriteLine(accessError.Message);
        }
        catch(SecurityException)
        {
            Console.WriteLine("You don't have permission to access this file!");
        }
        catch(NotSupportedException)
        {
            Console.WriteLine("Invalid path!");
        }
        catch(IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
    }
}
