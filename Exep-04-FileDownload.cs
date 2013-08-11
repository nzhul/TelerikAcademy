using System;
using System.Net;


class FileDownload
{
    static void Main()
    {
        Console.WriteLine("Enter the URL of the which you want to download:\nExample: \"http://www.d3bg.org/img/upload/tamplier/01.jpg\" ");
        string URL = Console.ReadLine();
        string fileName = GetFileName(URL);
        WebClient webClient = new WebClient();
        try
        {
            webClient.DownloadFile(URL, fileName);
            Console.WriteLine("The file was successfully downloaded!\nPlease check bin/Debug Directory!");
        }
        catch (WebException)
        {
            Console.WriteLine("Invalid adress or empty file.");
        }
        catch(NotSupportedException)
        {
            Console.WriteLine("");
        }
        finally
        {
            webClient.Dispose();
        }
    }

    private static string GetFileName(string URL)
    {
        string[] tokens = URL.Split('/');
        string fileName = "";

        if (tokens.Length > 0)
        {
            fileName = tokens[tokens.Length - 1];
        }
        else
        {
            fileName = URL;
        }
        return fileName;
    }
}
