namespace AllArtists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            Dictionary<string, int> numberOfSongs = new Dictionary<string, int>();
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlElement root = doc.DocumentElement;

            foreach (XmlElement node in root.ChildNodes)
            {
                string currentAuthor = node["artist"].InnerText.Trim();
                if (!numberOfSongs.ContainsKey(currentAuthor))
                {
                    numberOfSongs.Add(currentAuthor, 0);
                }

                foreach (XmlElement song in node["songs"])
                {
                    numberOfSongs[currentAuthor]++;
                }
            }

            foreach (var artist in numberOfSongs)
            {
                Console.WriteLine("{0} -> {1} songs", artist.Key, artist.Value);
            }
        }
    }
}
