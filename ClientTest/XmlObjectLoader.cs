using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using ClientTest.Entities;

namespace ClientTest
{
    public class XmlObjectLoader
    {
        public XmlObjectLoader()
        {
            var party = CreateParty();

            var xml = CreateXmlStringFromObject(party);

            HttpWebRequest request = CreateWebRequest();

            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(xmlBytes, 0, xmlBytes.Length);
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        string soapResult = sr.ReadToEnd();
                        Console.WriteLine(soapResult);
                    }
                }
            }
        }

        private Party CreateParty()
        {
            return new Party()
            {
                Sender = new Sender()
                {
                    TravelAgencySender = new TravelAgencySender()
                    {
                        Name = "Testing",
                        IATA_Number = "91210092",
                        AgencyID = "f96fe4th2dt45kd2m43ayktx",
                        Contacts = new List<Contact>()
                        {
                            new Contact()
                            {
                                EmailContact = new EmailContact()
                                {
                                    Address = "agentemail@admin.com"
                                }
                            }
                        }
                    }
                },
                Participants = new List<Participant>()
                {
                    new Participant()
                    {
                        AggregatorParticipant = new AggregatorParticipant()
                        {
                            SequenceNumber = "123",
                            Name = "Travelco",
                            AggregatorID = "00123456"
                        }
                    }
                }
            };

        }
        private string CreateXmlStringFromObject(Party party)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Party));
            var writer = new StringWriter();
            serializer.Serialize(writer, party);
            return writer.ToString();
        }

        private HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://test.api.ba.com/selling-distribution/AirShopping/V2");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Headers.Add("client-key", "f96fe4th2dt45kd2m43ayktx");
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

    }


}
