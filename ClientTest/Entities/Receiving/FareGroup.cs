using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientTest.Entities.Receiving
{
    public class FareGroup
    {
        [XmlAttribute]
        public string ListKey { get; set; }

        public Fare Fare { get; set; }
        public FareCode FareBasisCode { get; set; }
    }
}
