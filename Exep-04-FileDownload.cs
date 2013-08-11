using System;
using System.Net;


class FileDownload
{
    static void Main()
    {
        Console.WriteLine("Enter the URL of the which you want to download:\nExample: \"http://www.d3bg.org/img/upload/tamplier/01.jpg\" ");
        Uri uri = new Uri(Console.ReadLine());
        string fileName = System.IO.Path.GetFileName(uri.LocalPath);
        WebClient webClient = new WebClient();
        try
        {
            // "../../" changes the default location of the downloaded file to two directories above!
            webClient.DownloadFile(uri, "../../" + fileName);
            Console.WriteLine("The file was successfully downloaded!\n!");
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
}
