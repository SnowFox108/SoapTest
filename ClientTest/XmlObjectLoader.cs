using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using ClientTest.Entities;
using Type = ClientTest.Entities.Type;

namespace ClientTest
{
    public class XmlObjectLoader
    {
        public XmlObjectLoader()
        {
            var airShopping = CreateAirShopping();

            var xml = CreateXmlStringFromObject(airShopping);

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


        private AirShoppingRQ CreateAirShopping()
        {
            return new AirShoppingRQ()
            {
                Document = new Document()
                {
                    Name = "BA"
                },
                Party = new Party()
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
                },
                Travelers = new List<Traveler>()
                {
                    new Traveler()
                    {
                        AnonymousTraveler = new AnonymousTraveler()
                        {
                            PTC = "ADT",
                            Age = new Age()
                            {
                                BirthDate = "1988-06-07"
                            }
                        }
                    }
                },
                CoreQuery = new CoreQuery()
                {
                    OriginDestinations = new List<OriginDestination>()
                    {
                        new OriginDestination()
                        {
                            Departure = new Departure()
                            {
                                AirportCode = "LHR",
                                Date = "2018-08-26"
                            },
                            Arrival = new Arrival()
                            {
                                AirportCode = "DME"
                            }
                        },
                        new OriginDestination()
                        {
                            Departure = new Departure()
                            {
                                AirportCode = "DME",
                                Date = "2018-08-29"
                            },
                            Arrival = new Arrival()
                            {
                                AirportCode = "LHR"
                            }
                        }
                    }
                },
                Preference = new Preference()
                {
                    FarePreferences = new FarePreferences()
                    {
                        Types = new List<Type>()
                        {
                            new Type()
                            {
                                Code = "759"
                            }
                        }
                    },
                    CabinPreferences = new CabinPreferences()
                    {
                       CabinType = new CabinType
                       {
                           Code = "5"
                       }
                    }
                }
            };

        }

        private string CreateXmlStringFromObject(AirShoppingRQ airShopping)
        {
            var soap = new SoapEnvelope()
            {
                body = new ResponseBody<AirShoppingRQ>
                {
                    AirShoppingRQ = airShopping
                }
            };
            XmlSerializer serializer = new XmlSerializer(typeof(SoapEnvelope));
            var writer = new StringWriter();
            serializer.Serialize(writer, soap);
            return writer.ToString();
        }

        private HttpWebRequest CreateWebRequest()
        {
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
