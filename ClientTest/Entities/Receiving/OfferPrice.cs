using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientTest.Entities.Receiving
{
    public class OfferPrice
    {
        [XmlAttribute]
        public int OfferItemID { get; set; }

        public RequestedDate RequestedDate { get; set; }
    }
}
