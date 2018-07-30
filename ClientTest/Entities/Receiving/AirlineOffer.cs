using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientTest.Entities.Receiving
{
    public class AirlineOffer
    {
        [XmlAttribute]
        public bool RequestedDateInd { get; set; }

        public PricedOffer PricedOffer { get; set; }
    }
}
