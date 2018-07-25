using Microsoft.Web.Services3.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using ClientTest.Entities.Receiving;

namespace ClientTest
{
    public class SoapXmlReader
    {
        public SoapXmlReader()
        {
            var path = "Xml\\Return\\AirShoppingRS.xml";
            //var path = "Xml\\Return\\Errors.xml";
            string xml = File.ReadAllText(path);
            var stream = new FileStream(path, FileMode.Open);

            ISoapFormatter formatter = new SoapPlainFormatter();
            var result = (AirShoppingRS)formatter.Deserialize(stream).GetBodyObject(typeof(AirShoppingRS), "http://www.iata.org/IATA/EDIST");
            stream.Close();

            //XDocument xDoc = XDocument.Load(new StringReader(xml));

            //var unwrappedResponse = xDoc.Descendants((XNamespace) "http://schemas.xmlsoap.org/soap/envelope/" + "Body");

            //var result = unwrappedResponse.First().FirstNode.ToString();

            //XmlSerializer deSerializer = new XmlSerializer(typeof(AirShoppingRS));
            //using (StringReader reader = new StringReader(result))
            //{
            //    var air = deSerializer.Deserialize(reader);
            //}
        }
    }
}
