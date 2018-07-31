using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ClientTest.Entities.Receiving
{
    public class CurrencyMetadata
    {
        [XmlAttribute]
        public string MetadataKey { get; set; }

        public int Decimals { get; set; }
    }
}
