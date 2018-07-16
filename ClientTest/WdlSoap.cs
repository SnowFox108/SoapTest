using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using ClientTest.Entities;
using ClientTest.MySellingService;

namespace ClientTest
{
    public class WdlSoap
    {
        public WdlSoap()
        {

            var client =
                new MySellingService.
                    PricedAvailabilityDistributionAdapterPortTypeClient(); // SellingDistributionAdapterPortTypeClient();
            var airShopping = new MySellingService.AirShoppingRQ();

            airShopping.Version = "16.1";

            airShopping.Document = new MsgDocumentType()
            {
                Name = "BA"
            };

            airShopping.Party = new MsgPartiesType()
            {
                Sender = new MsgPartiesTypeSender()
                {
                    Item = new TravelAgencySenderType()
                    {
                        Contacts = new ContactsContact[]
                        {
                            new ContactsContact()
                            {
                                EmailContact = new EmailType()
                                {
                                    Address = new EmailTypeAddress(){ Value = "ndc@ba.com" }
                                }
                            }, 
                        },
                        Name = "Travel Centre Clapham",
                        IATA_Number = "91210092",
                        AgencyID = new AgencyID_Type() { Value = "Travel Centre Clapham Limited"}
                    }
                }
            };

            airShopping.Travelers = new TravelersTraveler[]
            {
                new TravelersTraveler()
                {
                    AnonymousTraveler = new AnonymousTravelerType[]
                    {
                        new AnonymousTravelerType()
                        {
                            PTC = new TravelerCoreTypePTC() { Value = "ADT"},
                            Age = new TravelerCoreTypeAge()
                            {
                                Item = new TravelerCoreTypeAgeBirthDate()
                                {
                                    Value = new DateTime(1988, 06, 07)
                                }
                            }
                        }
                    }
                }
            };

            airShopping.CoreQuery = new AirShoppingRQCoreQuery()
            {
                Item = new AirShopReqAttributeQueryType()
                {
                    OriginDestination = new AirShopReqAttributeQueryTypeOriginDestination[]
                    {
                        new AirShopReqAttributeQueryTypeOriginDestination()
                        {
                            Departure = new MySellingService.Departure()
                            {
                                AirportCode = new FlightDepartureTypeAirportCode()
                                {
                                    Value = "LHR"
                                },
                                Date = new DateTime(2018, 08, 26)
                            },
                            Arrival = new FlightArrivalType()
                            {
                                AirportCode = new FlightArrivalTypeAirportCode()
                                {
                                    Value = "DME"
                                }
                            }
                        },
                        new AirShopReqAttributeQueryTypeOriginDestination()
                        {
                            Departure = new MySellingService.Departure()
                            {
                                AirportCode = new FlightDepartureTypeAirportCode()
                                {
                                    Value = "DME"
                                },
                                Date = new DateTime(2018, 09, 26)
                            },
                            Arrival = new FlightArrivalType()
                            {
                                AirportCode = new FlightArrivalTypeAirportCode()
                                {
                                    Value = "LHR"
                                }
                            }
                        },
                    }
                }
            };

            airShopping.Preference = new AirShoppingRQPreference()
            {
                FarePreferences = new FarePreferencesType()
                {
                    Types = new FarePreferencesTypeType[]
                    {
                        new FarePreferencesTypeType()
                        {
                            Code = "759"
                        },
                    }
                },
                CabinPreferences = new CabinPreferencesType()
                {
                    CabinType = new MySellingService.CabinType[]
                    {
                        new MySellingService.CabinType()
                        {
                            Code = "5"
                        },
                    }
                }
            };

            using (new OperationContextScope(client.InnerChannel))
            {
                //Add a HTTP Header to an outgoing request
                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Client-key"] = "f96fe4th2dt45kd2m43ayktx";
                //requestMessage.Headers["SOAPAction"] = "AirShoppingV01";
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
                var request = new AirShoppingRQV01(airShopping);
                var response = client.AirShoppingV01(request);

                if (response.AirShoppingRS.Items.Any())
                {
                    foreach (var item in response.AirShoppingRS.Items)
                    {
                        var resultItem = item;
                    }
                }
            }

            //Console.WriteLine(response);
        }
    }
}
