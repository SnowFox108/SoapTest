using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest.Entities.Receiving
{
    public class DataLists
    {
        public List<AnonymousTraveler> AnonymousTravelerList { get; set; }
        public List<Disclosures> DisclosureList { get; set; }
        public List<FareGroup> FareList { get; set; }
        public List<FlightSegment> FlightSegmentList { get; set; }
        public List<Flight> FlightList { get; set; }
        public List<OriginDestination> OriginDestinationList { get; set; }
        public List<PriceClass> PriceClassList { get; set; }
    }
}
