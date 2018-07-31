using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientTest.Entities.Receiving
{
    public class PriceClass
    {
        [XmlAttribute]
        public string ObjectKey { get; set; }

        public string Name { get; set; }
        public List<Description> Descriptions { get; set; }
    }
}
