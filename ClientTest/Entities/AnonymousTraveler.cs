using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientTest.Entities
{
    public class AnonymousTraveler
    {
        [XmlAttribute]
        public string Objectkey { get; set; }
        public string PTC { get; set; }
        public Age Age { get; set; }
    }
}
