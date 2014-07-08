using PersonModule.PersonDefinitions;
using System;
using System.Xml;
using System.Xml.Linq;
using TeamOOP.Utilities;

namespace PersonModule
{
    public class Principal : Employee
    {
        public Principal(string firstName,
            string lastName,
            string egn,
            ContractType contractType,
            int id,
            decimal salary,
            int rating)
            : base(firstName,
                lastName,
                egn,
                Position.Principal,
                contractType,
                id,
                salary,
                rating)
        {

        }

        override public XElement toXML()
        {
            XElement principalNode = new XElement("Principal");
            principalNode.Add(base.toXML());
            return principalNode;
        }

        public Principal(XmlNode xmlNode)
            :base(
                xmlNode.SelectSingleNode("Employee/PresonalDetails/FirstName").InnerText,
                xmlNode.SelectSingleNode("Employee/PresonalDetails/LastName").InnerText,
                xmlNode.SelectSingleNode("Employee/PresonalDetails/EGN").InnerText,
                Position.Principal,
                (ContractType)Enum.Parse(typeof(ContractType), xmlNode.SelectSingleNode("Employee/ContractType").InnerText),
                int.Parse(xmlNode.SelectSingleNode("Employee/ID").InnerText),
                decimal.Parse(xmlNode.SelectSingleNode("Employee/Salary").InnerText),
                int.Parse(xmlNode.SelectSingleNode("Employee/Rating").InnerText)
            )
        {
        }

    }
}
