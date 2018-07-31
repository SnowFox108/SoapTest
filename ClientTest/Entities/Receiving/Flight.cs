using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientTest.Entities.Receiving
{
    public class Flight
    {
        [XmlAttribute]
        public string FlightKey { get; set; }

        public Journey Journey { get; set; }
        public string SegmentReferences { get; set; }
    }
}
