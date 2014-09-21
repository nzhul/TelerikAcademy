using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://localhost:22205/api");

            var request = new RestRequest("/Songs/All", Method.GET);
            //request.AddParameter("Title", "Song 1");
            //request.AddParameter("Year", "1999");
            //request.AddParameter("Genre", "Metal");
            //request.AddParameter("Length", "3");
            //request.AddParameter("Producer", "Company");

            // execute the request
            RestResponse response = client.Execute(request) as RestResponse;
            var content = response.Content;

            Console.WriteLine(content);
        }
    }
}
