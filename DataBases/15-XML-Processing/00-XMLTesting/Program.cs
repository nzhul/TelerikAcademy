namespace XMLTesting
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
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            XmlNode catalog = doc.DocumentElement;

            foreach (XmlNode node in catalog.ChildNodes)
            {
                double oldPrice = double.Parse(node["price"].InnerText.Trim());
                double newPrice = oldPrice * 1.2;
                node["price"].InnerText = newPrice.ToString();
            }

            doc.Save("../../catalog.xml");

        }
    }
}
