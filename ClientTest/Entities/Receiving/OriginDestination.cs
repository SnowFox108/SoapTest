using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientTest.Entities.Receiving
{
    public class OriginDestination
    {
        [XmlAttribute]
        public string OriginDestinationKey { get; set; }

        public string DepartureCode { get; set; }
        public string ArrivalCode { get; set; }
        public string FlightReferences { get; set; }
    }
}
