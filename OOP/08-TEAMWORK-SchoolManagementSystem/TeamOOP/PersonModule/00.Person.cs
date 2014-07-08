namespace PersonModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    using TeamOOP.Utilities;
   
    public abstract class Person : IStorable<Person>
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string EGN { get; protected set; }
        private string _hometown;

        public string HomeTown
        {
            get { return _hometown; }
            set { _hometown = value; }
        }

        public Person(string firstName, string lastName, string egn, string hometown = "Unknown")
        {
            if (firstName == string.Empty || 
                lastName == string.Empty ||
                egn == string.Empty)
            {
                throw new ArgumentException("Human params cannot be empty string");
            }

            if (firstName == null ||
                lastName == null ||
                egn == null)
            {
                throw new ArgumentNullException("Human params cannot be null.");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.EGN = egn;
            this.HomeTown = hometown;
        }

        virtual public XElement toXML()
        {
            var person = this;
            XElement personNode = new XElement("PresonalDetails");
            personNode.Add(new XElement("FirstName", person.FirstName));
            personNode.Add(new XElement("LastName", person.LastName));
            personNode.Add(new XElement("EGN", person.EGN));
            personNode.Add(new XElement("HomeTown", person.HomeTown));
            return personNode;
        }

        public void UpdatePersonalDetails(string newFirstName, string newLastName, string newEGN, string newHometown = "Unknown")
        {
            if (newFirstName == string.Empty ||
                newLastName == string.Empty ||
                newEGN == string.Empty)
            {
                throw new ArgumentException("Human names cannot be empty string");
            }

            if (newFirstName == null ||
                newLastName == null ||
                newEGN == null)
            {
                throw new ArgumentNullException("Human params cannot be null.");
            }
            this.FirstName = newFirstName;
            this.LastName = newLastName;
            this.EGN = newEGN;
            this.HomeTown = newHometown;
        }

    }

}
