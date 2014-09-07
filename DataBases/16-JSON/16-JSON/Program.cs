using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using JSON;

namespace _JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. The RSS feed is at http://forums.academy.telerik.com/feed/qa.rss 
            //2. Download the content of the feed programmatically
            //   You can use WebClient.DownloadFile()

            var webClient = new WebClient();
            string xmlFilePath = "../../../telerik.xml";
            webClient.DownloadFile("http://forums.academy.telerik.com/feed/qa.rss ", xmlFilePath);

            //3. Parse the XML from the feed to JSON
            var xmlNode = XElement.Load("../../../telerik.xml");
            string xmlToJson = JsonConvert.SerializeXNode(xmlNode, Newtonsoft.Json.Formatting.Indented);

            //4. Parse the XML from the feed to JSON
            JObject jsonObj = JObject.Parse(xmlToJson);
            foreach (var item in jsonObj["rss"]["channel"]["item"])
            {
                // Console.WriteLine(item["title"]);
            }

            //5. Parse the JSON string to POCO
            var poco = JsonConvert.DeserializeObject<RootObject>(xmlToJson);
            foreach (var item in poco.Rss.Channel.Item)
            {
                Console.WriteLine(item.Title);
            }

            //6. Using the parsed objects create a HTML page that lists all questions from the RSS 
            //   their categories and a link to the question's page

            StringBuilder html = new StringBuilder("<body>\n\t<ul>\n");
            foreach (var item in poco.Rss.Channel.Item)
            {
                html.AppendLine("\t\t<li>Question : " + item.Title + " Category : " + item.Category + "Link : " + item.Link + "</li>");
            }

            html.AppendLine("\t</ul>\n</body>");
            Console.WriteLine(html);
        }
    }
}
