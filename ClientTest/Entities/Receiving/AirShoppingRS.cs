using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Web.Services3.Security;

namespace ClientTest.Entities.Receiving
{
    public class AirShoppingRS
    {
        [XmlAttribute]
        public string Version { get; set; }

        public List<Error> Errors { get; set; }
        public Success Success { get; set; }

        public Document Document { get; set; }
        public ShoppingResponseID ShoppingResponseID { get; set; }
        public OffersGroup OffersGroup { get; set; }
        public DataLists DataLists { get; set; }
        public Metadata Metadata { get; set; }
    }
}
