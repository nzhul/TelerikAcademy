using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SongCountXPath
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> numberOfSongs = new Dictionary<string, int>();
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            string xPathQuery = "/catalog";

            XmlNodeList songsList = doc.SelectNodes(xPathQuery);

            foreach (XmlNode node in songsList)
            {
                Console.WriteLine(node.InnerXml);
            }
        }
    }
}
