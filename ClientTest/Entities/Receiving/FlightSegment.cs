using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientTest.Entities.Receiving
{
    public class FlightSegment
    {
        [XmlAttribute]
        public string SegmentKey { get; set; }
        public Departure Departure { get; set; }
        public Arrival Arrival { get; set; }
        public MarketingCarrier MarketingCarrier { get; set; }
        public OperatingCarrier OperatingCarrier { get; set; }
        public Equipment Equipment { get; set; }
        public FlightDetail FlightDetail { get; set; }
    }
}
