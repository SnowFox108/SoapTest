using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClientTest
{
    public class QuickSoap
    {
        public QuickSoap()
        {
            Execute();
        }
        public void Execute()
        {
            HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml($"<Party>" +
                                    $"<Sender>" +
                                    $"<TravelAgencySender>" +
                                    $"<Name>Testing for developement</Name>" +
                                    $"<Contacts>" +
                                    $"<Contact>" +
                                    $"<EmailContact>" +
                                    $"<Address>agentemailaddress@abc.com</Address>" +
                                    $"</EmailContact>" +
                                    $"</Contact>" +
                                    $"</Contacts>" +
                                    $"<IATA_Number>91210092</IATA_Number>" +
                                    $"<AgencyID>bse568jeq7btmrevdk52rw2u</AgencyID>" +
                                    $"</TravelAgencySender>" +
                                    $"</Sender>" +
                                    $"<Participants>" +
                                    $"<Participant>" +
                                    $"<AggregatorParticipant SequenceNumber=\"123\">" +
                                    $"<Name>Travelco</Name>" +
                                    $"<AggregatorID>00123456</AggregatorID>" +
                                    $"</AggregatorParticipant>" +
                                    $"</Participant>" +
                                    $"</Participants>" +
                                    $"</Party>");

            var result = soapEnvelopeXml.InnerXml;
            Console.WriteLine(result);

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
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

        public HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://test.api.ba.com/selling-distribution/AirShopping/V2");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Headers.Add("client-key", "bse568jeq7btmrevdk52rw2u");
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
    }
}
