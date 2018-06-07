using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace ClientTest
{
    public class XmlFlieLoader
    {
        public XmlFlieLoader()
        {
            //var path = "Xml\\postjob.xml";
            //var path = "AirShopping_Non_IATA_Agent.xml";
            //var path = "AirShopping_Corporate_TMC.xml";
            //var path = "Xml\\Post_Ba_NDC_Services.xml";
            //var path = "Xml\\Post_Ba_NDC_Services_New.xml";
            var path = "Xml\\AirShoppingRQ0.xml";

            var utf8 = new UTF8Encoding(false);

            string xml = File.ReadAllText(path);

            XDocument xmlDoc = XDocument.Parse(xml);

            HttpWebRequest request = CreateWebRequest();
            var result = xmlDoc.ToString();

            Console.WriteLine(result);

            using (Stream stream = request.GetRequestStream())
            {
                xmlDoc.Save(stream);
            }
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    Console.WriteLine(soapResult);
                }
            }

        }

        private HttpWebRequest CreateWebRequest()
        {
            //var url = @"https://test.api.ba.com/selling-distribution/AirShopping/V1";
            var url = @"https://test.api.ba.com/selling-distribution/AirShopping/V2";
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Headers.Add("Client-key", "f96fe4th2dt45kd2m43ayktx");
            webRequest.Headers.Add("SOAPAction", "AirShoppingV01");
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

    }
}
