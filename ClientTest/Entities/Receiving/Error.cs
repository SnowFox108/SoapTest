using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientTest.Entities.Receiving
{
    public class Error
    {
        [XmlAttribute]
        public string ShortText { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
    }
}
