using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ClientTest.Entities.Receiving
{
    public class AirlineOffers
    {
        public int TotalOfferQuantity { get; set; }
        public string Owner { get; set; }

        [XmlElement("AirlineOffer")]
        public List<AirlineOffer> Offers { get; set; }

    }
}
