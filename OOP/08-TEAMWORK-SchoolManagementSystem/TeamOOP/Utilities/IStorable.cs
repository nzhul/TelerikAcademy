using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TeamOOP.Utilities
{
    public interface IStorable<T>
    {
        XElement toXML();
        // T createFromXML(XElement xmlRecord);
    }
}
