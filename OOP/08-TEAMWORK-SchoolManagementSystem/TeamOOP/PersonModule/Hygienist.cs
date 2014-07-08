using PersonModule.PersonDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PersonModule
{
    public class Hygienist : Employee
    {
        public Hygienist(string firstName, 
            string lastName, 
            string egn, 
            ContractType contractType, 
            int id,
            decimal salary,
            int rating)
                : base(firstName, 
                    lastName, 
                    egn, 
                    Position.Hygienist, 
                    contractType, 
                    id, 
                    salary,
                    rating)      
        {
            
        }

        override public XElement toXML()
        {
            XElement hygenistNode = new XElement("Hygenist");
            hygenistNode.Add(base.toXML());
            return hygenistNode;
        }

        public Hygienist(XmlNode xmlNode)
            : base(
                xmlNode.SelectSingleNode("Employee/PresonalDetails/FirstName").InnerText,
                xmlNode.SelectSingleNode("Employee/PresonalDetails/LastName").InnerText,
                xmlNode.SelectSingleNode("Employee/PresonalDetails/EGN").InnerText,
                Position.Hygienist,
                (ContractType)Enum.Parse(typeof(ContractType), xmlNode.SelectSingleNode("Employee/ContractType").InnerText),
                int.Parse(xmlNode.SelectSingleNode("Employee/ID").InnerText),
                decimal.Parse(xmlNode.SelectSingleNode("Employee/Salary").InnerText),
                int.Parse(xmlNode.SelectSingleNode("Employee/Rating").InnerText)
            )
        {
        }

    }
}
