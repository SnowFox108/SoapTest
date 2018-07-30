using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ClientTest.Entities.Receiving
{
    public class Disclosures
    {
        [XmlAttribute]
        public string ListKey { get; set; }
        [XmlElement("Description")]
        public List<Description> Descriptions { get; set; }
    }
}
