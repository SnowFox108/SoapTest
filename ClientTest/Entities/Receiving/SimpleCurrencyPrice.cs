using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientTest.Entities.Receiving
{
    public class SimpleCurrencyPrice
    {
        [XmlAttribute]
        public string Code { get; set; }
        [XmlText]
        public decimal Value { get; set; }
    }
}
