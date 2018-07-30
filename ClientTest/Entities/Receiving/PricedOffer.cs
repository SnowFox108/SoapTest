using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ClientTest.Entities.Receiving
{
    public class PricedOffer
    {
        [XmlElement("OfferPrice")]
        public List<OfferPrice> OfferPrices { get; set; }
    }
}
