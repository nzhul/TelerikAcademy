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
    public class Administrator : Employee
    {
        public Administrator(string firstName, 
            string lastName, 
            string egn, 
            ContractType contractType, 
            int id,
            decimal salary,
            int rating)
                : base(firstName, 
                    lastName, 
                    egn, 
                    Position.Administrator, 
                    contractType, 
                    id, 
                    salary,
                    rating)
        {
            
        }

        override public XElement toXML()
        {
            XElement administratorNode = new XElement("Administrator");
            administratorNode.Add(base.toXML());
            return administratorNode;
        }

        public Administrator(XmlNode xmlNode)
            : base(
                xmlNode.SelectSingleNode("Employee/PresonalDetails/FirstName").InnerText,
                xmlNode.SelectSingleNode("Employee/PresonalDetails/LastName").InnerText,
                xmlNode.SelectSingleNode("Employee/PresonalDetails/EGN").InnerText, 
                Position.Administrator,
                (ContractType)Enum.Parse(typeof(ContractType), xmlNode.SelectSingleNode("Employee/ContractType").InnerText),
                int.Parse(xmlNode.SelectSingleNode("Employee/ID").InnerText),
                decimal.Parse(xmlNode.SelectSingleNode("Employee/Salary").InnerText),
                int.Parse(xmlNode.SelectSingleNode("Employee/Rating").InnerText)
            )
        {
        }

    }
}
