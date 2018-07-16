using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientTest.Entities
{
    public class AirShoppingRQ
    {

        [XmlAttribute]
        public string Version { get; set; }

        public Document Document { get; set; }
        public Party Party { get; set; }
        public List<Traveler> Travelers { get; set; }
        public CoreQuery CoreQuery { get; set; }
        public Preference Preference { get; set; }

        public AirShoppingRQ()
        {
            Version = "16.1";
        }

    }
}
